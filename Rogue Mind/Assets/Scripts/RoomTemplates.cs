using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public int chanceOf3DoorsSpawned; // percentage chance a room with 3 doors will spawn
    public float waitTime;
    public bool spawnedEndRoom;
    public GameObject endRoomPlaceHolder;

    private void Update()
    {
        if(waitTime<= 0 && !spawnedEndRoom)
        {
            exitRoom();
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void exitRoom()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if(i == rooms.Count -1)
            {
                Instantiate(endRoomPlaceHolder, rooms[i].transform.position, Quaternion.identity);// spawns a placeholder for the last room at the end of the list
                spawnedEndRoom = true;
            }
        }
    }

}
