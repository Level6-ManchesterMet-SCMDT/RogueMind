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

            
           
            
            //TO DO, SPAWNING 3 DOORS OCCASIONALLY CAUSES OVERLAP AND BLOCKS OFF THE PATH TO THE EXIT
           
            if (number > templates.chanceOf3DoorsSpawned)
            {
                if (direction == OpeningDirection.BOTTOM)
                {
                    rand = Random.Range(0, templates.bottomRooms.Length - 3);// rooms with 2 or less doors
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    spawned = true;
                }
                else if (direction == OpeningDirection.TOP)
                {  
                    rand = Random.Range(0, templates.topRooms.Length - 3);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
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
                //spawned = true;
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
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                /*if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.BOTTOM)
                {
                    Debug.Log("BottomLeft");
                    rand = Random.Range(0, templates.bottomLeftRooms.Length);
                    Instantiate(templates.bottomLeftRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                    
                    Destroy(gameObject, waitTime);
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.LEFT)
                {
                    Debug.Log("BottomLeft");
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.BOTTOM)
                {
                    Debug.Log("BottomRight");
                    rand = Random.Range(0, templates.bottomRightRooms.Length);
                    Instantiate(templates.bottomRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.RIGHT)
                {
                    Debug.Log("BottomRight");
                    Destroy(gameObject, waitTime);
                    spawned = true;
                    Debug.Log("BottomRight");
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.TOP)
                {
                    Debug.Log("TopLeft");
                    rand = Random.Range(0, templates.topLeftRooms.Length);
                    Instantiate(templates.topLeftRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.LEFT)
                {
                    Debug.Log("TopLeft");
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.TOP)
                {
                    Debug.Log("TopRight");
                    rand = Random.Range(0, templates.topRightRooms.Length);
                    Instantiate(templates.topRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                    Destroy(gameObject, waitTime);
                }
                else if(other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.RIGHT)
                {
                    Debug.Log("TopRight");
                    spawned = true;
                    Destroy(gameObject, waitTime);
                    
                }
                */
                
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);// spawns a closed off room if there is accidental overlap
                Destroy(gameObject, waitTime);
            }
            //spawned = true;
        }
        
    }
}
