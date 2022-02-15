using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyData scriptable;// the scriptable object that is used to store data for the enemy type

    public float speed;// enemies movement speed
    public float activeSpeed;// enemies movement speed
    public float reducedSpeed;// enemies movement speed
    public GameObject target;// the target the enemy is following (the player)
    public float health;//enemy health
    public float damage;// the damage value of the enemy
    public string name;// name of the enemy
    public GameObject bulletType;//type of bullet an enemy will use

    public SpriteRenderer spriteRenderer;// the enemies sprite renderer
    public Rigidbody2D rigidBody;// the enemies rigidbody
    public BoxCollider2D collider;// the boxcollider on the enemy
    public GameObject DopamineDrop;
    public GameObject FoodDrop;

    public Animator anim;

    public Color flashColor;//the colour it flashes to
    public Color regularColor;//the colour it returns to 
    public float flashDuration;//the duration of each flash
    public int numberOfFlashes;// the number of flashes after getting hit

    Vector2 movement;// a vector used for movement
    public EnemyTypes.EnemyAI aiType;// the type of AI being used

    public EnemyState currentState;// the enemies state
    public int stunnedDuration;
    Vector3 direction;
    public float healthHeal = 10;
    public DrugManagerScript modifiers;//finds the drugs modifiers

    public enum EnemyState
	{
        Moving,//when the enemy is moving 
        Attacking,// when the enemy is attacking
        Stunned,//when the enemy is stunned
	}
    private IEnumerator FlashCo()// used for Iframes and flashing
    {
        int temp = 0;
        
        while (temp < numberOfFlashes)// as long as there are more flashes to do
        {
            spriteRenderer.color = flashColor;// set the sprite the flash colour
            yield return new WaitForSeconds(flashDuration);//wait the duration
            spriteRenderer.color = regularColor;//set the sprite the normal colour
            yield return new WaitForSeconds(flashDuration);//wait the duration
            temp++;//increase the count in the loop by 1

        }
        
    }
    void Start()
    {
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        anim = GetComponent<Animator>();
        collider = this.gameObject.GetComponent<BoxCollider2D>();//assign collider
        currentState = EnemyState.Moving;//set base movement state
        target = GameObject.FindWithTag("Player");//find the player and rigid body
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();// grab the sprite renderer

        health = scriptable.hp;// set all variables to that of the scriptable object assigned to the enemy
        speed = scriptable.movementSpeed;
        activeSpeed = speed;
        reducedSpeed = speed / 2;
        damage = scriptable.damage;
        name = scriptable.name;
        bulletType = scriptable.bulletType;
        anim.runtimeAnimatorController = scriptable.anim;
        if(scriptable.sprite != null)// if there is a sprite then set it otherwise it sticks with the prefabs default
		{
            spriteRenderer.sprite = scriptable.sprite;
        }

        if(scriptable.aiType == EnemyTypes.EnemyAI.Shooter)
		{
            transform.localRotation = Quaternion.Euler(0, 180, 0);
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
	private void OnTriggerExit2D(Collider2D collision)
	{
        activeSpeed = speed;
	}


	public void Stun(int duration)// used to set an enemy in stun
	{
        stunnedDuration = duration;//set the duration
        currentState = EnemyState.Stunned;//set the state to stunned
    }

    void StunnedUpdate()// counts down the stunned timer and sets state to moving once the stun is over
	{
        if(stunnedDuration > 0)
		{
            stunnedDuration--;
		}
        else
		{
            currentState = EnemyState.Moving;
		}

	}

    //---------------------------------FOLLOWER-----------------------------------
    void FollowerUpdate()
    {
        switch (currentState)// runs the collider code associated with this enemies ai type
        {
            case EnemyState.Moving:
                Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
                if(transform.position.x < target.transform.position.x)
				{
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
				{
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
                //rigidBody.rotation = angle;// rotate enemy to face player
                direction.Normalize();//normalize
                movement = direction;//set movement vector 

                break;
            case EnemyState.Stunned:
                StunnedUpdate();
                break;
        }
         
    }
    void FollowerFixedUpdate(Vector2 direction)
    {
        if (currentState == EnemyState.Moving)//as long as he should be moving
        {
            rigidBody.MovePosition((Vector2)transform.position + (direction * activeSpeed * Time.deltaTime));// move position by speed in direction over time
        }
    }
    private void FollowerOnTriggerEnter(Collider2D collision)
	{
        if ((collision.tag == "Bullet"))//if collide with a bullet
        {
            health -= collision.GetComponent<BulletScript>().damage;// reduce health by bullets damage value
            StartCoroutine(FlashCo());
            Destroy(collision.gameObject);//destroy bullet
            if (target.GetComponent<PlayerCollisionScript>().doctorDrug)
            {
                target.GetComponent<PlayerCollisionScript>().HealDamage(healthHeal);
            }
            if (health <= 0)
            {
                for (int i = 0; i < Random.RandomRange(0, 3); i++)
                {
                    Instantiate(DopamineDrop, transform.position + (new Vector3(i, i, 0)), transform.rotation);
                }
                if(Random.RandomRange(0, 3) == 1 && modifiers.chefDrug)
                {
                    Instantiate(FoodDrop, transform.position, transform.rotation);
                }
                target.GetComponent<PlayerMovement>().killedEnemy = true;
                
                
                Destroy(gameObject);// if health 0 or below then die
            }
        }
        if ((collision.tag == "Melee"))//if collide with a melee attack
        {
            health -= target.GetComponent<MeleeScript>().damage;// reduce health by attacks damage value
            Stun(collision.GetComponent<HitScript>().stun);
            
            StartCoroutine(FlashCo());
            Vector3 moveDirection = target.transform.position - transform.position;// create a vector facing the opposite direction of the player
            rigidBody.AddForce(moveDirection.normalized * -collision.GetComponent<HitScript>().knockback);// push enemy in said direction by the hits knockback power
            if (target.GetComponent<PlayerCollisionScript>().doctorDrug)
            {
                target.GetComponent<PlayerCollisionScript>().HealDamage(healthHeal);
            }
            if (health <= 0)
            {
				for (int i = 0; i < Random.RandomRange(0,3); i++)
				{
                    Instantiate(DopamineDrop, transform.position+(new Vector3(i,i,0)),transform.rotation);
				}
                if (Random.RandomRange(0, 3) == 1 && modifiers.chefDrug)
                {
                    Instantiate(FoodDrop, transform.position, transform.rotation);
                }
                
                target.GetComponent<PlayerMovement>().killedEnemy = true;
                Destroy(gameObject);// if health 0 or below then die
            }
        }
        if ((collision.tag == "Trail"))//if collide with a bullet
        {
            health *= 0.9999f;// reduce health by bullets damage value
            activeSpeed = reducedSpeed;
            StartCoroutine(FlashCo());
            
            if (health <= 0)
            {
                for (int i = 0; i < Random.RandomRange(0, 3); i++)
                {
                    Instantiate(DopamineDrop, transform.position + (new Vector3(i, i, 0)), transform.rotation);
                }
                if (Random.RandomRange(0, 3) == 1 && modifiers.chefDrug)
                {
                    Instantiate(FoodDrop, transform.position, transform.rotation);
                }
                target.GetComponent<PlayerMovement>().killedEnemy = true;
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
                if (transform.position.x < target.transform.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
                //rigidBody.rotation = angle;// rotate enemy to face player
                direction.Normalize();//normalize
                movement = direction;//set movement vector 
                float dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < 1.5)//if close enough to the player
                {
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(NoseAttack());   //run attack
                }
                break;
            case EnemyState.Stunned:
                StunnedUpdate();
                break;
        }
        
    }
    void NoseFixedUpdate(Vector2 direction)
    {
        if(currentState == EnemyState.Moving)//as long as he should be moving
		{
            rigidBody.MovePosition((Vector2)transform.position + (direction * activeSpeed * Time.deltaTime));// move position by speed in direction over time
        }
        
    }
    private IEnumerator NoseAttack()
	{

        anim.SetTrigger("Attack");
        float m_ScaleX, m_ScaleY;
        float s_ScaleX, s_ScaleY;
        m_ScaleX = collider.size.x;
        m_ScaleY = collider.size.y;
        s_ScaleX = collider.size.x;
        s_ScaleY = collider.size.y;//save the collider and sprite renderers size
        yield return new WaitForSeconds(1);//pause
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX*2,m_ScaleY*2);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX * 2, s_ScaleY * 2);// double size for the hit
        Vector2 directionNow = new Vector2(direction.x,direction.y);

        rigidBody.MovePosition((Vector2)transform.position + (directionNow * activeSpeed));// move position by speed in direction over time
        yield return new WaitForSeconds(1);//wait
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX, m_ScaleX);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX, s_ScaleX);//return to original size
        
        currentState = EnemyState.Moving;//set moving again
        anim.SetTrigger("Move");
        //return null;
    }

    //---------------------------------SHOOTER-----------------------------------

    void ShooterUpdate()
	{
        Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
        rigidBody.rotation = angle;// rotate enemy to face player
        switch (currentState)// runs the collider code associated with this enemies ai type
        {
            case EnemyState.Moving:
                
                direction.Normalize();//normalize
                movement = direction;//set movement vector 
                float dist = Vector3.Distance(target.transform.position, transform.position);
                if (dist < 10)//if close enough to the player
                {
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(ShooterAttack());// shoot
                }
                break;
            case EnemyState.Stunned:
                StunnedUpdate();
                break;
        }
    }

    void ShooterFixedUpdate(Vector2 direction)
    {
        if (currentState == EnemyState.Moving)
        {
            rigidBody.MovePosition((Vector2)transform.position + (direction * activeSpeed * Time.deltaTime));// move position by speed in direction over time
        }
    }

    private IEnumerator ShooterAttack()
	{
        
        
        GameObject bullet = Instantiate(bulletType, transform.position,transform.rotation);//Create a bullet from the prefab
        bullet.GetComponent<BulletScript>().damage = damage;//sets the damage of the bullet it shoots to the enemies damage
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();//save it's rigidBody
        rigidBody.AddForce(-(transform.right) * 4, ForceMode2D.Impulse);//add a force based on the bulletForce Variable 
        yield return new WaitForSeconds(1);//pause inbetween shots
        currentState = EnemyState.Moving;//set back to moving

        
	}
}
