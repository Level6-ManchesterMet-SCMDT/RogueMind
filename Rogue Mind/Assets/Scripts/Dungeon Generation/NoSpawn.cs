using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpawn : MonoBehaviour
{
    //UNUSED FOR NOW MAY BE USED IN THE FUTURE
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StartRoom")|| collision.CompareTag("SpawnedRoom")|| collision.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
    }
}
