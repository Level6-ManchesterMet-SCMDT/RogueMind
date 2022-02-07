using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOverlap : MonoBehaviour
{
    float waitTime = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0) 
        {
            waitTime = 0;
            gameObject.tag = "SpawnedRoom";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnedRoom" && gameObject.tag == "Room"|| collision.gameObject.tag == "SpawnedRoom" && gameObject.tag == "EndCap") 
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("SpawnPoint")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
