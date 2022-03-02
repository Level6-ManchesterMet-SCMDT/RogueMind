using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject UI;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UI = GameObject.FindGameObjectWithTag("UI");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
		{
            UI.GetComponent<ShopMenu>().CloseVending();
		}
    }

    public void heal1()
	{
        if(player.GetComponent<PlayerCollisionScript>().Dopamine >= 10)
		{
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 10;
            player.GetComponent<PlayerCollisionScript>().HealDamage(20);
        }

        UI.GetComponent<ShopMenu>().CloseVending();
    }
    public void heal2()
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= 20)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 20;
            player.GetComponent<PlayerCollisionScript>().HealDamage(40);
        }
        UI.GetComponent<ShopMenu>().CloseVending();
    }
    public void heal3()
    {
        if (player.GetComponent<PlayerCollisionScript>().Dopamine >= 30)
        {
            player.GetComponent<PlayerCollisionScript>().Dopamine -= 30;
            player.GetComponent<PlayerCollisionScript>().HealDamage(60);
        }
        UI.GetComponent<ShopMenu>().CloseVending();
    }
}
