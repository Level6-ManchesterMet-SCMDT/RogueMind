using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletCounterScript : MonoBehaviour
{
    public Text text;// the bullet counter text
    public GameObject player;// the player
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();//find the text
        player = GameObject.FindGameObjectWithTag("Player");//find the player
    }

    // Update is called once per frame
    void Update()
    {
		for (int i = 0; i < player.GetComponent<ShootingScript>().currentBullets; i++)
		{
            transform.GetChild(i).gameObject.active = true;
		}
        for (int i = 0; i < player.GetComponent<ShootingScript>().maxBullets - player.GetComponent<ShootingScript>().currentBullets; i++)
        {
            transform.GetChild(i+ player.GetComponent<ShootingScript>().currentBullets).gameObject.active = false;
        }

    }
    public void Reload()
	{

	}
}
