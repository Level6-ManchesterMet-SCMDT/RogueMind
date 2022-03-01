using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms2Door_endCap; // array of top opening rooms
    public GameObject[] bottomRooms2Door_endCap; // array of bottom opening rooms
    public GameObject[] rightRooms2Door_endCap; // array of right opening rooms
    public GameObject[] leftRooms2Door_endCap; // array of left opening rooms

    public GameObject bottomLeftRooms; // array of bottom and left opening rooms
    public GameObject bottomRightRooms;  // array of bottom and right opening rooms
    public GameObject topLeftRooms;  // array of top and left opening rooms
    public GameObject topRightRooms;  // array of top and right opening rooms
    

    public GameObject[] topRooms2Doors; // array of top opening with 2 or more door rooms
    public GameObject[] bottomRooms2Doors;// array of bottom opening with 2 or more door rooms
    public GameObject[] leftRooms2Doors;// array of left opening with 2 or more door rooms
    public GameObject[] rightRooms2Doors;// array of right opening with 2 or more door rooms

    public GameObject[] topRooms3Doors; // array of rooms with a top opening with 3 doors
    public GameObject[] bottomRooms3Doors;// array of rooms with a bottom opening with 3 doors
    public GameObject[] leftRooms3Doors;// array of rooms with a left opening with 3 doors
    public GameObject[] rightRooms3Doors;// array of rooms with a right opening with 3 doors

    public GameObject[] rightEndcap; // right opening with no other openings
    public GameObject[] leftEndCap; // left opening with no other openings
    public GameObject[] topEndCap; // top opening with no other openings
    public GameObject[] bottomEndCap; // bottom opening with no other openings

    public GameObject closedRoom; // used for testing

    public List<GameObject> rooms;// creates a list of rooms spawned in the dungeon
    public List<GameObject> endRooms;// creates a list of end cap rooms spawned in the dungeon
    public int chanceOf3DoorsSpawned; // percentage chance a room with 3 doors will spawn

    // wait times for special rooms to spawn
    public float spawnWaitTime;
    public float itemWaitTime;
    public float shopWaitTime;

    // bools to check if the rooms have been spawned
    public bool spawnedEndRoom;
    public bool spawnedItemRoom;
    public bool spawnedShopRoom;
    public int rand;
    //
    public GameObject endRoomPlaceHolder;

    //ints to hold the minimum and maximum number of rooms in the dungeon
    public int minNumberOfRooms;
    public int maxNumberOfRooms;

    private void Update()
    {
        if(spawnWaitTime<= 0 && !spawnedEndRoom) // if the wait time is 0 and the end room hasnt been spawned yet
        {
            spawnWaitTime = 0;
            ExitRoom();
        }
        else// counts down the timer
        {
            spawnWaitTime -= Time.deltaTime;
        }

        if(itemWaitTime <= 0&& !spawnedItemRoom) // if the wait time is 0 and the item room hasnt been spawned
        {
            itemWaitTime = 0;
            ItemRoom();
        }
        else // counts down the timer
        {
            itemWaitTime -= Time.deltaTime;
        }
        if (shopWaitTime <= 0 && !spawnedShopRoom)
        {
            shopWaitTime = 0;
            ShopRoom();
        }
        else
        {
            shopWaitTime -= Time.deltaTime;
        }
    }

    void ExitRoom()
    {
        for (int i = 0; i < rooms.Count; i++) // for loop for each room in the rooms list
        {
            if(i == rooms.Count -1) // gets the last room in the list
            {
                Debug.Log(rooms[i].gameObject + "is End Room");
                rooms[i].GetComponent<Activator>().isEndRoom = true; // gets the final rooms activator script and sets the end room to true
                spawnedEndRoom = true; // stops the timer counting down
            }
        }
    }
    void ItemRoom()
    {
         rand = Random.Range(0, rooms.Count-1); // picks a random number from all the end rooms in the level

        for (int i = 0; i < rooms.Count; i++) // for loop for all the rooms in the end room list
        {
            if(i == rand) // if the random number is the same as the current room in the for loop
            {
                if (rooms[i].GetComponent<Activator>().isShopRoom == false&& rooms[i].GetComponent<Activator>().isEndRoom == false)// checks to see if the room is already a shop room
                {
                    Debug.Log(rooms[i].gameObject + "is Item Room");
                    rooms[i].GetComponent<Activator>().isItemRoom = true;// makes the room an item room
                    spawnedItemRoom = true;// item room is set to true
                }
                else
                {
                    rand = Random.Range(0, rooms.Count - 1);
                    i = 0;
                }    
            }
        }
    }
    void ShopRoom()
    {
         rand = Random.Range(0, endRooms.Count - 1);// picks a random number from all the end rooms in the level
        Debug.Log(rand);
        for (int i = 0; i < endRooms.Count; i++)// for loop for all the rooms in the end room list
        {
            if (i == rand)// if the random number is the same as the current room in the for loop
            {
                if (endRooms[i].GetComponent<Activator>().isItemRoom == false)// checks to see if the room is already a item room
                {
                    Debug.Log(endRooms[i].gameObject + "is shop Room");
                    endRooms[i].GetComponent<Activator>().isShopRoom = true; // spawns the shop room
                    spawnedShopRoom = true;
                }
                else
                {
                    rand = Random.Range(0, endRooms.Count - 1);
                    i = 0;
                }
                Debug.Log(i);
            }
        }
    }

}
