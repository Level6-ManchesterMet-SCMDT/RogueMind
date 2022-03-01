using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
		{
            this.gameObject.SetActive(false);
		}
    }

    public void heal1()
	{
        if(player.GetComponent<PlayerCollisionScript>().Dopamine >= 20)
		{
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 20;
            player.GetComponent<PlayerCollisionScript>().HealDamage(20);
        }
        this.gameObject.active = false;
	}
    public void heal2()
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= 40)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 40;
            player.GetComponent<PlayerCollisionScript>().HealDamage(40);
        }
        this.gameObject.active = false;
    }
    public void heal3()
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= 60)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 60;
            player.GetComponent<PlayerCollisionScript>().HealDamage(60);
        }
        this.gameObject.active = false;
    }
}
