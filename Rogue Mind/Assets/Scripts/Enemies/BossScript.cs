using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{
    public BossData scriptable;// the scriptable object that is used to store data for the enemy type

    public float speed;// enemies movement speed
    public GameObject target;// the target the enemy is following (the player)
    public float health;//enemy health
    public float damage;// the damage value of the enemy
    public string name;// name of the enemy
    public GameObject spawnable;//type of bullet an enemy will use

    public SpriteRenderer spriteRenderer;// the enemies sprite renderer
    public Rigidbody2D rigidBody;// the enemies rigidbody
    public BoxCollider2D collider;// the boxcollider on the enemy
    public BoxCollider2D otherCollider;// the boxcollider on the enemy
    public GameObject DopamineDrop;// the dopamine drops 
    public GameObject CashDrop;// the dopamine drops 
    public EnemyData spawnableData;// what the boss can spawn
    public GameObject nameText;

    public GameObject healthBar;// the healthbar for the player
    public Animator anim;

    public GameObject winMenu;

    Vector2 movement;// a vector used for movement
    public BossTypes.BossAI aiType;// the type of AI being used

   

    public EnemyState currentState;// the enemies state
    public int timer = 0;

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
        spawnable = scriptable.spawnable;
        spawnableData = scriptable.spawnableData;
        Debug.Log(health.ToString());
        healthBar.GetComponent<HealthBarScirpt>().SetMaxHealth(health);
        anim.runtimeAnimatorController = scriptable.anim;
        nameText.GetComponent<Text>().text = name;

        winMenu = GameObject.FindGameObjectWithTag("UI");

        if (scriptable.sprite != null)// if there is a sprite then set it otherwise it sticks with the prefabs default
        {
            spriteRenderer.sprite = scriptable.sprite;
        }

        switch (scriptable.aiType)// runs the update associated with this enemies ai type
        {
            case BossTypes.BossAI.BigSam:
                BigSamStart();
                break;

        }
    }
    // Update is called once per frame
    void Update()
    {
        switch (scriptable.aiType)// runs the update associated with this enemies ai type
        {
            case BossTypes.BossAI.BigSam:
                BigSamUpdate();
                
                break;

        }
    }
    private void FixedUpdate()// runs the fixed update associated with this enemies ai type
    {
        switch (scriptable.aiType)
        {
            case BossTypes.BossAI.BigSam:
            BigSamFixedUpdate(movement);
            break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//2d trigger collider
    {
        switch (scriptable.aiType)
        {
            case BossTypes.BossAI.BigSam:
            BigSamCollision(collision);
            break;
        }
    }

    void BigSamStart()
	{
        
	}

    void BigSamUpdate()
    {
        switch (currentState)// runs the collider code associated with this enemies ai type
        {
            case EnemyState.Moving:
                timer++;
                Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
                //rigidBody.rotation = angle;// rotate enemy to face player
                direction.Normalize();//normalize
                movement = direction;//set movement vector 
                if (transform.position.x < target.transform.position.x)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                float dist = Vector3.Distance(target.transform.position, transform.position);
                /*if (dist < 3.5)//if close enough to the player
                {
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(BigSamAttack());   //run attack
                }*/
                if(timer > 2000)
				{
                    timer = 0;
                    currentState = EnemyState.Attacking;//stop moving
                    StartCoroutine(BigSamAssembleTheMinions());
                    
                }
                break;
            case EnemyState.Attacking:

                break;
        }
    }
    void BigSamFixedUpdate(Vector2 direction)
    {
        if (currentState == EnemyState.Moving)//as long as he should be moving
        {
            rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));// move position by speed in direction over time
        }

    }

    private IEnumerator BigSamAttack()
	{
        float m_ScaleX, m_ScaleY;
        float s_ScaleX, s_ScaleY;
        m_ScaleX = collider.size.x;
        m_ScaleY = collider.size.y;
        s_ScaleX = collider.size.x;
        s_ScaleY = collider.size.y;//save the collider and sprite renderers size
        yield return new WaitForSeconds(1);//pause
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX * 2, m_ScaleY * 2);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX * 2, s_ScaleY * 2);// double size for the hit
        yield return new WaitForSeconds(1);//wait
        this.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(m_ScaleX, m_ScaleX);
        this.gameObject.GetComponent<SpriteRenderer>().size = new Vector2(s_ScaleX, s_ScaleX);//return to original size
        currentState = EnemyState.Moving;//set moving again
    }

    private IEnumerator BigSamAssembleTheMinions()
	{
        anim.SetTrigger("BeginWobble");
        yield return new WaitForSeconds(1);//pause
        anim.SetTrigger("BeforeThrowUp");
        yield return new WaitForSeconds(0.5f);//pause
        anim.SetTrigger("Start Throwing Up");
        for (int i = 0; i < Random.RandomRange(3,5); i++)//a random number
		{
            GameObject spawned = Instantiate(spawnable, transform.position+ new Vector3(0,-3,0), transform.rotation);//summon the spawnables 
            spawned.GetComponent<EnemyScript>().scriptable = spawnableData;//apply their scriptable for data
            yield return new WaitForSeconds(0.5f);//pause
        }
        anim.SetTrigger("Sad");
        yield return new WaitForSeconds(1f);//pause
        currentState = EnemyState.Moving;//set moving again
        anim.SetTrigger("BackToWalk");

    }
    void BigSamCollision(Collider2D collision)
    {
        if ((collision.tag == "Bullet"))//if collide with a bullet
        {
            health -= collision.GetComponent<BulletScript>().damage;// reduce health by bullets damage value
            healthBar.GetComponent<HealthBarScirpt>().SetHealth(health);//update health bar
            Destroy(collision.gameObject);//destroy bullet
            DeathCheck();
        }
        if ((collision.tag == "Melee"))//if collide with a melee attack
        {
            health -= target.GetComponent<MeleeScript>().damage;// reduce health by attacks damage value
            healthBar.GetComponent<HealthBarScirpt>().SetHealth(health);//update health bar
            Vector3 moveDirection = target.transform.position - transform.position;// create a vector facing the opposite direction of the player
            rigidBody.AddForce(moveDirection.normalized * -collision.GetComponent<HitScript>().knockback);// push enemy in said direction by the hits knockback power
            DeathCheck();
        }
    }

    void DeathCheck()
    {
        if (health <= 0)
        {
            for (int i = 0; i < Random.RandomRange(5, 10); i++)
            {
                Instantiate(DopamineDrop, transform.position + (new Vector3(i / 10, i / 10, 0)), transform.rotation);
            }
            for (int i = 0; i < Random.RandomRange(5, 10); i++)
            {
                Instantiate(CashDrop, transform.position + (new Vector3(i / 10, i / 10, 0)), transform.rotation);
            }
            StartCoroutine(winState());
            // if health 0 or below then die
        }
    }
    IEnumerator winState()
    {
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5f);

        winMenu.GetComponent<WinScreen>().OpenWinScreen();
        Destroy(gameObject);
    }

}