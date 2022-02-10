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
        text.text = "Bullets: " + player.GetComponent<ShootingScript>().currentBullets.ToString() + "/" + player.GetComponent<ShootingScript>().maxBullets.ToString();// set the text to the current bullets plus the max bullets
    }
}
