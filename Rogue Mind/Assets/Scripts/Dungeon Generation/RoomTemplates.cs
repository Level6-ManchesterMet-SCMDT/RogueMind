using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject[] bottomLeftRooms;
    public GameObject[] bottomRightRooms;
    public GameObject[] topLeftRooms;
    public GameObject[] topRightRooms;

    public GameObject[] topRooms2PlusDoors;
    public GameObject[] bottomRooms2PlusDoors;
    public GameObject[] leftRooms2PlusDoors;
    public GameObject[] rightRooms2PlusDoors;

    public GameObject rightEndcap;
    public GameObject leftEndCap;
    public GameObject topEndCap;
    public GameObject bottomEndCap;

    public GameObject closedRoom;

    public List<GameObject> rooms;
    public List<GameObject> endRooms;
    public int chanceOf3DoorsSpawned; // percentage chance a room with 3 doors will spawn
    public float spawnWaitTime;
    public float itemWaitTime;
    public float shopWaitTime;
    public bool spawnedEndRoom;
    public bool spawnedItemRoom;
    public bool spawnedShopRoom;
    public GameObject endRoomPlaceHolder;

    public int minNumberOfRooms;
    public int maxNumberOfRooms;

    private void Update()
    {
        if(spawnWaitTime<= 0 && !spawnedEndRoom)
        {
            spawnWaitTime = 0;
            exitRoom();
        }
        else
        {
            spawnWaitTime -= Time.deltaTime;
        }

        if(itemWaitTime <= 0&& !spawnedItemRoom)
        {
            itemWaitTime = 0;
            ItemRoom();
        }
        else
        {
            itemWaitTime -= Time.deltaTime;
        }
        if (shopWaitTime <= 0 && !spawnedShopRoom)
        {
            itemWaitTime = 0;
            ShopRoom();
        }
        else
        {
            shopWaitTime -= Time.deltaTime;
        }
    }

    void exitRoom()
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if(i == rooms.Count -1)
            {
                //Instantiate(endRoomPlaceHolder, rooms[i].transform.position, Quaternion.identity);// spawns a placeholder for the last room at the end of the list
                rooms[i].GetComponent<Activator>().isEndRoom = true;
                spawnedEndRoom = true;
            }
        }
    }
    void ItemRoom()
    {
        int rand = Random.Range(0, endRooms.Count-1);

        for (int i = 0; i < endRooms.Count; i++)
        {
            if(i == rand)
            {
                if (endRooms[i].GetComponent<Activator>().isShopRoom == false)
                {
                    endRooms[i].GetComponent<Activator>().isItemRoom = true;
                    spawnedItemRoom = true;
                }
                else
                {
                    if (i+1 >= endRooms.Count - 1)
                    {
                        endRooms[i - 1].GetComponent<Activator>().isItemRoom = true;
                        spawnedItemRoom = true;
                    }
                    else if(i-1<=0)
                    {
                        endRooms[i + 1].GetComponent<Activator>().isItemRoom = true;
                        spawnedItemRoom = true;
                    }
                }
                    
            }
        }
    }
    void ShopRoom()
    {
        int rand = Random.Range(0, endRooms.Count - 1);

        for (int i = 0; i < endRooms.Count; i++)
        {
            if (i == rand)
            {
                if (endRooms[i].GetComponent<Activator>().isItemRoom == false)
                {
                    endRooms[i].GetComponent<Activator>().isShopRoom = true;
                    spawnedShopRoom = true;
                }
                else
                {
                    if (i + 1 >= endRooms.Count - 1)
                    {
                        endRooms[i - 1].GetComponent<Activator>().isShopRoom = true;
                        spawnedShopRoom = true;
                    }
                    else if (i - 1 <= 0)
                    {
                        endRooms[i + 1].GetComponent<Activator>().isShopRoom = true;
                        spawnedShopRoom = true;
                    }
                }

            }
        }
    }

}
