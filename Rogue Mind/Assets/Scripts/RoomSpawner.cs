using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum OpeningDirection{BOTTOM, LEFT, TOP, RIGHT, EMPTY };// can pick what rooms need to go on the spawn points

    public OpeningDirection direction;

    private RoomTemplates templates;
    private int rand;// defines a random value to pick from the rooms array
    public bool spawned = false;
    //public bool dontSpawn = false;
    float waitTime = 10f;
    float delay = 2.0f;
    GameObject room;


    private void Start()
    {
        Destroy(gameObject, waitTime);
        
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); // adds the rooms to a list
        Invoke("Spawn", 0.3f);// spawns the rooms
    }

    void Spawn()
    {
        if (!spawned)// checks if the spawn point has already spawned a room
        {
            int number = Random.Range(0, 100);// used for 3 doors
            //TO DO, SPAWNING 3 DOORS OCCASIONALLY CAUSES OVERLAP AND BLOCKS OFF THE PATH TO THE EXIT
           
           
                if (direction == OpeningDirection.BOTTOM)
                {
                    rand = Random.Range(0, templates.bottomRooms.Length - 3);// rooms with 2 or less doors
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);// creates a room that has a bottom opening from the bottom rooms list
                spawned = true;
            }
                else if (direction == OpeningDirection.TOP)
                {  
                    rand = Random.Range(0, templates.topRooms.Length - 3);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);// creates a room that has a top opening from the Top rooms list
                spawned = true;
            }
                else if (direction == OpeningDirection.LEFT)
                {
                    rand = Random.Range(0, templates.leftRooms.Length - 3);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                spawned = true;

            }
                else if (direction == OpeningDirection.RIGHT)
                {
                    rand = Random.Range(0, templates.rightRooms.Length - 3);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                spawned = true;
            }
            
            /*
             else if (number < templates.chanceOf3DoorsSpawned)
             {
                 if (direction == OpeningDirection.BOTTOM)
                 {
                     rand = Random.Range(templates.bottomRooms.Length - 3, templates.bottomRooms.Length );// all rooms avaliable
                     room = Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);

                 }
                 else if (direction == OpeningDirection.TOP)
                 {

                     rand = Random.Range(templates.topRooms.Length - 3, templates.topRooms.Length );
                     room = Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);


                 }
                 else if (direction == OpeningDirection.LEFT)
                 {
                     rand = Random.Range(templates.leftRooms.Length - 3, templates.leftRooms.Length);
                     room = Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);

                 }
                 else if (direction == OpeningDirection.RIGHT)
                 {
                     rand = Random.Range(templates.rightRooms.Length - 3, templates.rightRooms.Length);
                     room = Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);

                 }
                 spawned = true;
             }*/
            spawned = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            
            
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
        if (other.CompareTag("Destroyer"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
/* if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.BOTTOM  )
                {
                    Debug.Log("BottomLeft");
                    rand = Random.Range(0, templates.bottomLeftRooms.Length);
                    room = Instantiate(templates.bottomLeftRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                    
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.LEFT )
                {
                    Debug.Log("BottomLeft");
                    spawned = true;
                    Destroy(gameObject, waitTime);

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.BOTTOM )
                {
                    Debug.Log("BottomRight");
                    rand = Random.Range(0, templates.bottomRightRooms.Length);
                    room = Instantiate(templates.bottomRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.RIGHT )
                {
                    Debug.Log("BottomRight");
                    
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.TOP )
                {
                    Debug.Log("TopLeft");
                    rand = Random.Range(0, templates.topLeftRooms.Length);
                    room = Instantiate(templates.topLeftRooms[rand], transform.position, transform.rotation);

                    spawned = true;
                    
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.LEFT )
                {
                    Debug.Log("TopLeft");
                    
                    spawned = true;
                    
                    Destroy(gameObject, waitTime);

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.TOP )
                {
                    
                    Debug.Log("TopRight");
                    rand = Random.Range(0, templates.topRightRooms.Length);
                    room = Instantiate(templates.topRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;

                    
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.RIGHT )
                {
                    Debug.Log("TopRight");      
                    spawned = true;
                    Destroy(gameObject, waitTime);


                }
                if (other.GetComponent<RoomSpawner>().spawned == true && spawned == false)

                {
                    dontSpawn = true;
                    Destroy(gameObject);
                }
                */
