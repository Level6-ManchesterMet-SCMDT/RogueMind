using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOverlap : MonoBehaviour
{
    float waitTime = 2f; 

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0) 
        {
            waitTime = 0;
            gameObject.tag = "SpawnedRoom"; // changes the tag of a room that has recently been instansiated to spawned room
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // used to stop rooms overlapping, if a room is spawned on top of a spawned room(a room previously there)and will delete the object
    {
        if (collision.gameObject.tag == "SpawnedRoom" && gameObject.tag == "Room"|| collision.gameObject.tag == "SpawnedRoom" && gameObject.tag == "EndCap"||collision.CompareTag("StartRoom"))
        {
            Destroy(gameObject);// destroys the overlapped room
        }
        if (collision.gameObject.CompareTag("SpawnPoint")) 
        {
            //Destroy(collision.gameObject);// destroys the overlapped spawnpoint
        }
    }
}
