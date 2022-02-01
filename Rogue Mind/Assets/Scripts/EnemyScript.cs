using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyData scriptable;// the scriptable object that is used to store data for the enemy type

    public float speed;// enemies movement speed
    public GameObject target;// the target the enemy is following (the player)
    public float health;//enemy health
    public float damage;// the damage value of the enemy
    public string name;// name of the enemy
    public GameObject bulletType;//type of bullet an enemy will use

    public SpriteRenderer spriteRenderer;// the enemies sprite renderer
    public Rigidbody2D rigidBody;// the enemies rigidbody
    public BoxCollider2D collider;// the boxcollider on the enemy
    public GameObject DopamineDrop;

    
  
    Vector2 movement;// a vector used for movement
    public EnemyTypes.EnemyAI aiType;// the type of AI being used

    public EnemyState currentState;// the enemies state

    public enum EnemyState
	{
        Moving,//when the enemy is moving 
        Attacking,// when the enemy is attacking
	}

    void Start()
    {
        collider = this.gameObject.GetComponent<BoxCollider2D>();//assign collider
        currentState = EnemyState.Moving;//set base movement state
        target = GameObject.FindWithTag("Player");//find the player and rigid body
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();// grab the sprite renderer

        health = scriptable.hp;// set all variables to that of the scriptable object assigned to the enemy
        speed = scriptable.movementSpeed;
        damage = scriptable.damage;
        name = scriptable.name;
        bulletType = scriptable.bulletType;
        if(scriptable.sprite != null)// if there is a sprite then set it otherwise it sticks with the prefabs default
		{
            spriteRenderer.sprite = scriptable.sprite;
        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (scriptable.aiType)// runs the update associated with this enemies ai type
        {
            case EnemyTypes.EnemyAI.Follower:
                FollowerUpdate();
                break;
            case EnemyTypes.EnemyAI.Shooter:
                ShooterUpdate();
                break;
            case EnemyTypes.EnemyAI.Nose:
                NoseUpdate();
                break;
        }
    }
    private void FixedUpdate()// runs the fixed update associated with this enemies ai type
    {
        switch (scriptable.aiType)
        {
            case EnemyTypes.EnemyAI.Follower:
                FollowerFixedUpdate(movement);// runs character movement
                break;
            case EnemyTypes.EnemyAI.Shooter:
                ShooterFixedUpdate(movement);
                break;
            case EnemyTypes.EnemyAI.Nose:
                NoseFixedUpdate(movement);
                break;
        }    
    }
    private void OnTriggerEnter2D(Collider2D collision)//2d trigger collider
    {
        switch (scriptable.aiType)// runs the collider code associated with this enemies ai type
        {
            case EnemyTypes.EnemyAI.Follower:
                FollowerOnTriggerEnter(collision);// runs character movement
                break;
            case EnemyTypes.EnemyAI.Shooter:
                FollowerOnTriggerEnter(collision);
                break;
            case EnemyTypes.EnemyAI.Nose:
                FollowerOnTriggerEnter(collision);
                break;
        }
    }

    //---------------------------------FOLLOWER-----------------------------------
    void FollowerUpdate()
    {
        Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
        rigidBody.rotation = angle;// rotate enemy to face player
        direction.Normalize();//normalize
        movement = direction;//set movement vector 
    }
    void FollowerFixedUpdate(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));// move position by speed in direction over time
    }
    private void FollowerOnTriggerEnter(Collider2D collision)
	{
        if ((collision.tag == "Bullet"))//if collide with a bullet
        {
            health -= collision.GetComponent<BulletScript>().damage;// reduce health by bullets damage value
            Destroy(collision.gameObject);//destroy bullet
            if (health <= 0)
            {
                for (int i = 0; i < Random.RandomRange(0, 3); i++)
                {
                    Instantiate(DopamineDrop, transform.position + (new Vector3(i, i, 0)), transform.rotation);
                }
                Destroy(gameObject);// if health 0 or below then die
            }
        }
        if ((collision.tag == "Melee"))//if collide with a melee attack
        {
            health -= target.GetComponent<MeleeScript>().damage;// reduce health by attacks damage value
            Vector3 moveDirection = target.transform.position - transform.position;// create a vector facing the opposite direction of the player
            rigidBody.AddForce(moveDirection.normalized * -collision.GetComponent<HitScript>().knockback);// push enemy in said direction by the hits knockback power
            if (health <= 0)
            {
				for (int i = 0; i < Random.RandomRange(0,3); i++)
				{
                    Instantiate(DopamineDrop, transform.position+(new Vector3(i,i,0)),transform.rotation);
				}
                Destroy(gameObject);// if health 0 or below then die
            }
        }
    }


    //---------------------------------NOSE-----------------------------------
    void NoseUpdate()
    {
        switch (currentState)// runs the collider code associated with this enemies ai type
        {
            case EnemyState.Moving:
                Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
                rigidBody.rotation = angle;// rotate enemy to face player
                direction.Normalize();//normalize
                movement = direction;//set movement vector 
                float dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < 1.5)//if close enough to the player
                {
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(NoseAttack());   //run attack
                }
                break;
            case EnemyState.Attacking:
   
                break;
        }
        
    }
    void NoseFixedUpdate(Vector2 direction)
    {
        if(currentState == EnemyState.Moving)//as long as he should be moving
		{
            rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));// move position by speed in direction over time
        }
        
    }
    private IEnumerator NoseAttack()
	{
        float m_ScaleX, m_ScaleY;
        float s_ScaleX, s_ScaleY;
        m_ScaleX = collider.size.x;
        m_ScaleY = collider.size.y;
        s_ScaleX = collider.size.x;
        s_ScaleY = collider.size.y;//save the collider and sprite renderers size
        yield return new WaitForSeconds(1);//pause
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX*2,m_ScaleY*2);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX * 2, s_ScaleY * 2);// double size for the hit
        yield return new WaitForSeconds(1);//wait
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX, m_ScaleX);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX, s_ScaleX);//return to original size
        currentState = EnemyState.Moving;//set moving again
        //return null;
    }

    //---------------------------------SHOOTER-----------------------------------

    void ShooterUpdate()
	{
        switch (currentState)// runs the collider code associated with this enemies ai type
        {
            case EnemyState.Moving:
                Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
                rigidBody.rotation = angle;// rotate enemy to face player
                direction.Normalize();//normalize
                movement = direction;//set movement vector 
                float dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < 10)//if close enough to the player
                {
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(ShooterAttack());// shoot
                }
                break;
            case EnemyState.Attacking:

                break;
        }
    }

    void ShooterFixedUpdate(Vector2 direction)
    {
        if (currentState == EnemyState.Moving)
        {
            rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));// move position by speed in direction over time
        }
    }

    private IEnumerator ShooterAttack()
	{
        
        
        GameObject bullet = Instantiate(bulletType, transform.position,transform.rotation);//Create a bullet from the prefab
        bullet.GetComponent<BulletScript>().damage = damage;
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();//save it's rigidBody
        rigidBody.AddForce(transform.right * 4, ForceMode2D.Impulse);//add a force based on the bulletForce Variable 
        yield return new WaitForSeconds(1);//pause inbetween shots
        currentState = EnemyState.Moving;//set back to moving

        //return null;
	}
}
