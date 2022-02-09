using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage = 1f;//the damage of the bullet
    // Start is called before the first frame update
    public DrugManagerScript modifiers;//finds the drugs modifiers
    void Start()
    {
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();// finds the modifiers
        Destroy(gameObject, 3);//after 5 seconds a bullet is destroyed 
        damage *= modifiers.gunDamageModifier;// the bullet's damage is affected by any modifiers
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter2D(Collision2D collision)//on hitting something
	{
        if((collision.gameObject.tag != "Player") && (collision.gameObject.tag != "Enemy"))//if it isn't a player or enemy
        {
            Destroy(gameObject);//Destroy the bullet
        }
        
	}
}
