using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum OpeningDirection{BOTTOM, LEFT, TOP, RIGHT, EMPTY };// can pick what rooms need to go on the spawn points

    public OpeningDirection direction;

    private RoomTemplates templates;
    private int rand;// defines a random value to pick from the rooms array
    private bool spawned = false;
    float waitTime = 4f;
    

    private void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);// spawns the rooms
    }

    void Spawn()
    {
        if (!spawned)
        {
            int number = Random.Range(0, 100);// used for 3 doors

            if (direction == OpeningDirection.BOTTOM) // spawns rooms with a door on the bottom
            {
                rand = Random.Range(0, templates.bottomRooms.Length -3);// rooms with 2 or less doors
                Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity); // spawns a room
            }
            else if (direction == OpeningDirection.TOP)// spawns rooms with a door on the top
            {
                rand = Random.Range(0, templates.topRooms.Length-3);
                Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
            }
            else if (direction == OpeningDirection.LEFT)// spawns rooms with a door on the left
            {
                rand = Random.Range(0, templates.leftRooms.Length-3);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
            }
            else if (direction == OpeningDirection.RIGHT)// spawns rooms with a door on the right
            {
                rand = Random.Range(0, templates.rightRooms.Length-3);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
            }
            spawned = true;
            
            //TO DO, SPAWNING 3 DOORS OCCASIONALLY CAUSES OVERLAP AND BLOCKS OFF THE PATH TO THE EXIT
            /*
            if (number > templates.chanceOf3DoorsSpawned)
            {
                if (direction == OpeningDirection.BOTTOM)
                {
                    rand = Random.Range(0, templates.bottomRooms.Length - 3);// rooms with 2 or less doors
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                }
                else if (direction == OpeningDirection.TOP)
                {  
                    rand = Random.Range(0, templates.topRooms.Length - 3);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity); 
                }
                else if (direction == OpeningDirection.LEFT)
                {
                    rand = Random.Range(0, templates.leftRooms.Length - 3);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                }
                else if (direction == OpeningDirection.RIGHT)
                {
                    rand = Random.Range(0, templates.rightRooms.Length - 3);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                }
                spawned = true;
            }
            if (number < templates.chanceOf3DoorsSpawned)
            {
                if (direction == OpeningDirection.BOTTOM)
                {
                    rand = Random.Range(templates.bottomRooms.Length - 3, templates.bottomRooms.Length );// all rooms avaliable
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                }
                else if (direction == OpeningDirection.TOP)
                {

                    rand = Random.Range(templates.topRooms.Length - 3, templates.topRooms.Length );
                   Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    
                }
                else if (direction == OpeningDirection.LEFT)
                {
                    rand = Random.Range(templates.leftRooms.Length - 3, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                }
                else if (direction == OpeningDirection.RIGHT)
                {
                    rand = Random.Range(templates.rightRooms.Length - 3, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                }
                spawned = true;
            }*/
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);// spawns a closed off room if there is accidental overlap
                Destroy(gameObject);
            }
            spawned = true;
        }
        
    }
}
