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

    public SpriteRenderer spriteRenderer;// the enemies sprite renderer
    public Rigidbody2D rigidBody;// the enemies rigidbody
   
    Vector2 movement;// a vector used for movement
    public EnemyTypes.EnemyAI aiType;// the type of AI being used

    void Start()
    {
        target = GameObject.FindWithTag("Player");//find the player and rigid body
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();// grab the sprite renderer

        health = scriptable.hp;// set all variables to that of the scriptable object assigned to the enemy
        speed = scriptable.movementSpeed;
        damage = scriptable.damage;
        name = scriptable.name;
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
                break;
        }
    }
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
                Destroy(gameObject);// if health 0 or below then die
            }

        }
    }
   
}
