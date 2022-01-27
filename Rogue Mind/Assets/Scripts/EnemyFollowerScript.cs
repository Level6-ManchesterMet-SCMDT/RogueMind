using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;// enemies movement speed

    public GameObject target;// the target the enemy is following (the player)

    public float health = 10f;//enemy health

    public Rigidbody2D rigidBody;// the enemies rigidbody
    Vector2 movement;// a vector used for movement

    public float damage;// the damage value of the enemy
    void Start()
    {
        target = GameObject.FindWithTag("Player");//find the player and rigid body
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //POSSIBLE ALTERNATIVE
        //rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);

        //transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

        Vector3 direction = target.transform.position - transform.position;// create a vec3 of the direction from the enemy to the player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;//set it to an angle
        rigidBody.rotation = angle;// rotate enemy to face player
        direction.Normalize();//normalize
        movement = direction;//set movement vector 
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);// runs character movement
    }
    void moveCharacter(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));// move position by speed in direction over time
    }
    private void OnTriggerEnter2D(Collider2D collision)//2d trigger collider
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
