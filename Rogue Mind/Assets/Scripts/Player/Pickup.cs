using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //public GameObject UI_Example;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//if it is the player that collides with the object
        {
            
            Destroy(gameObject);//destroy the object picked up
        }
    }
}
