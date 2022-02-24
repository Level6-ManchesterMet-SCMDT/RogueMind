using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
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
            
            if (collision.GetComponent<PlayerMovement>().isLeft)
            {

                currentpos = new Vector3(currentpos.x - pushAmount, currentpos.y, currentpos.z);
                collision.transform.position = currentpos;
            }
            if (collision.GetComponent<PlayerMovement>().isRight)
            {

                currentpos = new Vector3(currentpos.x + pushAmount, currentpos.y, currentpos.z);
                collision.transform.position = currentpos;
            }
        }
    }
}
