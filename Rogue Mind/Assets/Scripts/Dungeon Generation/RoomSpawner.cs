using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public enum OpeningDirection{BOTTOM, LEFT, TOP, RIGHT, EMPTY };// can pick what rooms need to go on the spawn points

    public OpeningDirection direction; //holds the enum value

    private RoomTemplates templates;// holds the gameobject with the different
    private int rand;// defines a random value to pick from the rooms array
    public int roomsSpawned;
    int random;
    public int cols = 0;
    public bool spawned = false;// checks if the spawnpoint has already spawned a room

    float WaitTime = 10f; // used to destroy a spawn point after a certain amount of time
    float Delay = 2.0f;

    GameObject room;


    private void Start()
    {
        Destroy(gameObject, WaitTime);
        random = Random.Range(0, 2);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); // finds the room templates
        Invoke("Spawn", 0.5f);// spawns the rooms
    }

    void Spawn()
    {
        if (!spawned)// checks if the spawn point has already spawned a room
        {
            int number = Random.Range(0, 100);// picks a random int from 1 to 100;
                                              //TO DO, SPAWNING 3 DOORS OCCASIONALLY CAUSES OVERLAP AND BLOCKS OFF THE PATH TO THE EXIT
            if (templates.rooms.Count > templates.minNumberOfRooms && templates.rooms.Count < templates.maxNumberOfRooms)// if the amount of rooms is larger than the minimum amounf but smaller than the maximum
            {
                if (number > templates.chanceOf3DoorsSpawned)// if the random value is a 2 door room
                {
                    switch(direction)
					{
                        case OpeningDirection.BOTTOM:
                            rand = Random.Range(0, templates.bottomRooms2Door_endCap.Length);// picks a random room with 2 or less doors (minus 3 because there are 3 rooms that have 3 doors with bottom openings)
                            Instantiate(templates.bottomRooms2Door_endCap[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;// creates a room that has a bottom opening from the bottom rooms list
                            break;
                        case OpeningDirection.TOP:
                            rand = Random.Range(0, templates.topRooms2Door_endCap.Length);
                            Instantiate(templates.topRooms2Door_endCap[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;// creates a room that has a top opening from the Top rooms list
                            break;
                        case OpeningDirection.LEFT :
                            rand = Random.Range(0, templates.leftRooms2Door_endCap.Length);
                            Instantiate(templates.leftRooms2Door_endCap[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;// creates a room that has a left opening from the left rooms list
                            break;
                        case OpeningDirection.RIGHT:
                            rand = Random.Range(0, templates.rightRooms2Door_endCap.Length);
                            Instantiate(templates.rightRooms2Door_endCap[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;// creates a room with a right opening from the right rooms list
                            break;
					}                
                    spawned = true; // sets the spawnpoint to have spawned a room
                }
                else if (number <= templates.chanceOf3DoorsSpawned) // if the random value is lower or equal to the the chance of a door being spawned
                {
                    switch (direction)
                    {
                        case OpeningDirection.BOTTOM:
                            rand = Random.Range(0, templates.bottomRooms3Doors.Length);//checks for bottom rooms 3 rooms avaliable and picks a random room from them
                            room = Instantiate(templates.bottomRooms3Doors[rand], transform.position, Quaternion.identity);// spawns the room
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.TOP:
                            rand = Random.Range(0, templates.topRooms3Doors.Length);//checks for top rooms 3 rooms avaliable and picks a random room from them
                            room = Instantiate(templates.topRooms3Doors[rand], transform.position, Quaternion.identity);// spawns the room
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.LEFT:
                            rand = Random.Range(0, templates.leftRooms3Doors.Length);//checks for left rooms 3 rooms avaliable and picks a random room from them
                            room = Instantiate(templates.leftRooms3Doors[rand], transform.position, Quaternion.identity);// spawns the room
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.RIGHT:
                            rand = Random.Range(0, templates.rightRooms3Doors.Length);//checks for right rooms 3 rooms avaliable and picks a random room from them
                            room = Instantiate(templates.rightRooms3Doors[rand], transform.position, Quaternion.identity); // spawns the room
                            roomsSpawned += 1;
                            break;
                    }                    
                    spawned = true;
                }

            }
            else if (templates.rooms.Count >= templates.maxNumberOfRooms)// checks if the max number of rooms has been reached and will only spawn room end 
            {
                switch (direction)
                {
                    case OpeningDirection.BOTTOM:
                        rand = Random.Range(0, templates.bottomEndCap.Length);
                        Instantiate(templates.bottomEndCap[rand], transform.position, Quaternion.identity);// creates a room that has a bottom opening from the bottom end cap list
                        roomsSpawned += 1;
                        break;
                    case OpeningDirection.TOP:
                        rand = Random.Range(0, templates.topEndCap.Length);
                        Instantiate(templates.topEndCap[rand], transform.position, Quaternion.identity);// creates a room that has a top opening from the Top end cap rooms list
                        roomsSpawned += 1;
                        break;
                    case OpeningDirection.LEFT:
                        rand = Random.Range(0, templates.leftEndCap.Length);
                        Instantiate(templates.leftEndCap[rand], transform.position, Quaternion.identity);// creates a room that has a left opening from the left end cap rooms list
                        roomsSpawned += 1;
                        break;
                    case OpeningDirection.RIGHT:
                        rand = Random.Range(0, templates.rightEndcap.Length);
                        Instantiate(templates.rightEndcap[rand], transform.position, Quaternion.identity);// creates a room that has a right opening from the tight end cap rooms list
                        roomsSpawned += 1;
                        break;
                }
                
                spawned = true;
            }
            else if (templates.rooms.Count<= templates.minNumberOfRooms) // if the amount of rooms is less than the minimum number of rooms
            {
                if (number > templates.chanceOf3DoorsSpawned) // if the random value is a 2 door room
                {
                    switch (direction)
                    {
                        case OpeningDirection.BOTTOM:
                            rand = Random.Range(0, templates.bottomRooms2Doors.Length);// rooms with 2 or less doors
                            Instantiate(templates.bottomRooms2Doors[rand], transform.position, Quaternion.identity);// creates a room that has a bottom opening from the bottom rooms list
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.TOP:
                            rand = Random.Range(0, templates.topRooms2Doors.Length);
                            Instantiate(templates.topRooms2Doors[rand], transform.position, Quaternion.identity);// creates a room that has a top opening from the Top rooms list   
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.LEFT:
                            rand = Random.Range(0, templates.leftRooms2Doors.Length);
                            Instantiate(templates.leftRooms2Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.RIGHT:
                            rand = Random.Range(0, templates.rightRooms2Doors.Length);
                            Instantiate(templates.rightRooms2Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
                    }                   
                    spawned = true;
                }
                else if (number <= templates.chanceOf3DoorsSpawned)
                {
                    switch(direction)
					{
                        case OpeningDirection.BOTTOM:
                            rand = Random.Range(0, templates.bottomRooms3Doors.Length);// all rooms avaliable
                            Instantiate(templates.bottomRooms3Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.TOP:
                            rand = Random.Range(0, templates.topRooms3Doors.Length);
                            Instantiate(templates.topRooms3Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.LEFT :
                            rand = Random.Range(0, templates.leftRooms3Doors.Length);
                            Instantiate(templates.leftRooms3Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
                        case OpeningDirection.RIGHT:
                            rand = Random.Range(0, templates.rightRooms3Doors.Length);
                            Instantiate(templates.rightRooms3Doors[rand], transform.position, Quaternion.identity);
                            roomsSpawned += 1;
                            break;
					}
                    
                    spawned = true;
                }
            }
            spawned = true;
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        //WORKING ON THIS, THINGS WILL BE FULLY COMMENTED AND CLEANED UP UPON COMPLETION
        if (other.CompareTag("SpawnPoint")) // checks if a spawnpoint collides with another spawnpoint
        {
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            cols++;

            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false && cols == 1)// if neither of the spawnpoints have spawned an object
            {
                if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.BOTTOM) //checks the direction of the other spawnpoint
                {
                    Debug.Log("BottomLeft");
                    //rand = Random.Range(0, templates.bottomLeftRooms.Length);
                    Instantiate(templates.bottomLeftRooms, transform.position, Quaternion.identity); // spawns a room 
                    roomsSpawned += 1;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.LEFT) // checks the direction of the other spawnpoint(same as before but reversed, stops rooms spawning on top of one another)
                {
                    spawned = true;
                    Destroy(gameObject, WaitTime); // destroys the spawnpoint after a certain amount of times
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.BOTTOM)
                {
                    Debug.Log("BottomRight");

                    Instantiate(templates.bottomRightRooms, transform.position, Quaternion.identity);
                    roomsSpawned += 1;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.RIGHT)
                {
                    Destroy(gameObject, WaitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.TOP)
                {
                    //rand = Random.Range(0, templates.topLeftRooms.Length);
                    Instantiate(templates.topLeftRooms, transform.position, Quaternion.identity);
                    roomsSpawned += 1;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.LEFT)
                {
                    Destroy(gameObject, WaitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.TOP)
                {
                    //rand = Random.Range(0, templates.topRightRooms.Length);
                    Instantiate(templates.topRightRooms, transform.position, Quaternion.identity);
                    roomsSpawned += 1;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.RIGHT)
                {
                    Destroy(gameObject, WaitTime);
                }

            }
            else if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false && cols > 1)// if neither of the spawnpoints have spawned an object
            {
                Debug.Log("SpawningClosed");
                Instantiate(templates.closedRoom, transform.position, Quaternion.Euler(0,0,0));
                Destroy(gameObject, WaitTime);
            }
            if(other.GetComponent<RoomSpawner>().roomsSpawned>=1)
            {
                Destroy(gameObject);
            }
            
        }
        
       
    }
}

    /* if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.BOTTOM) //checks the direction of the other spawnpoint
                {
                    Debug.Log("BottomLeft");
                    rand = Random.Range(0, templates.bottomLeftRooms.Length);
                    room = Instantiate(templates.bottomLeftRooms[rand], transform.position, transform.rotation); // spawns a room 
                    spawned = true;

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.LEFT) // checks the direction of the other spawnpoint(same as before but reversed, stops rooms spawning on top of one another)
                {
                    Debug.Log("BottomLeft");
                    spawned = true;
                    Destroy(gameObject, WaitTime); // destroys the spawnpoint after a certain amount of times

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.BOTTOM)
                {
                    Debug.Log("BottomRight");
                    rand = Random.Range(0, templates.bottomRightRooms.Length);
                    room = Instantiate(templates.bottomRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.BOTTOM && direction == OpeningDirection.RIGHT)
                {
                    Debug.Log("BottomRight");

                    spawned = true;
                    Destroy(gameObject, WaitTime);
                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.LEFT && direction == OpeningDirection.TOP)
                {
                    Debug.Log("TopLeft");
                    rand = Random.Range(0, templates.topLeftRooms.Length);
                    room = Instantiate(templates.topLeftRooms[rand], transform.position, transform.rotation);

                    spawned = true;

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.LEFT)
                {
                    Debug.Log("TopLeft");

                    spawned = true;

                    Destroy(gameObject, WaitTime);

                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.RIGHT && direction == OpeningDirection.TOP)
                {

                    Debug.Log("TopRight");
                    rand = Random.Range(0, templates.topRightRooms.Length);
                    room = Instantiate(templates.topRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;


                }
                else if (other.GetComponent<RoomSpawner>().direction == OpeningDirection.TOP && direction == OpeningDirection.RIGHT)
                {
                    Debug.Log("TopRight");
                    spawned = true;
                    Destroy(gameObject, WaitTime);


                }
                //Destroy(gameObject);
            }*/
               