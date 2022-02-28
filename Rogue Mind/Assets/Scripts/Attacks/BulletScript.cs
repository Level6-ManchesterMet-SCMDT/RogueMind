using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public CircleCollider2D colliderNonTrigger;
    public float damage = 1f;//the damage of the bullet
    public int timeTillDestroy = 3;// how long till the bullet automaticaly destroys itself
    // Start is called before the first frame update
    public DrugManagerScript modifiers;//finds the drugs modifiers
    void Start()
    {
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();// finds the modifiers
        Destroy(gameObject, timeTillDestroy);//after 5 seconds a bullet is destroyed 
        damage *= modifiers.gunDamageModifier;// the bullet's damage is affected by any modifiers
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)//on hitting something
	{
        if((collision.gameObject.tag != "Player") && (collision.gameObject.tag != "Enemy") && (collision.gameObject.tag != "EnemyBullet") && (collision.gameObject.tag != "Bullet"))//if it isn't a player or enemy
        {
            Destroy(gameObject);//Destroy the bullet
        }
        if (collision.gameObject.tag == "EnemyBullet"||collision.gameObject.tag=="Bullet"||collision.gameObject.tag =="Enemy")
        {
            StartCoroutine(TurnOffCollider());
        }
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(TurnOffCollider());
        }
    }
    IEnumerator TurnOffCollider()
    {

        colliderNonTrigger.enabled = false;

        yield return new WaitForSeconds(0.5f);

        colliderNonTrigger.enabled = true;
    }
}
