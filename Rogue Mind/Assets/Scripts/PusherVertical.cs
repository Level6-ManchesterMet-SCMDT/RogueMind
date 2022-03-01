using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PusherVertical : MonoBehaviour
{
    GameObject player;
    public Vector3 currentpos;
    public float pushAmount;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            currentpos = player.transform.position;
            if (collision == player.GetComponent<PlayerCollisionScript>().playerFeetBox)
            {
                if (collision.GetComponent<PlayerMovement>().isUp)
                {

                    currentpos = new Vector3(currentpos.x, currentpos.y + pushAmount, currentpos.z);
                    collision.transform.position = currentpos;
                }
                if (collision.GetComponent<PlayerMovement>().isDown)
                {

                    currentpos = new Vector3(currentpos.x, currentpos.y - pushAmount, currentpos.z);
                    collision.transform.position = currentpos;
                }
            }
        }
    }
}
