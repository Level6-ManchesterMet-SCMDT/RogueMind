using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    //bools to check if the room is a special room
    public bool isEndRoom = false; 
    public bool isItemRoom = false;
    public bool isShopRoom = false;

    //holds the gameobjects for the different special room templates
    public GameObject endRoomTemplate;
    public GameObject itemRoomTemplate;
    public GameObject shopRoomTemplate;

    public GameObject shopTileSet;

    // Update is called once per frame
    void Update()
    {
        // will activate the different templates depending on the different room type
        if (isEndRoom)
        {
            endRoomTemplate.SetActive(true);
        }
        if (isItemRoom)
        {
            itemRoomTemplate.SetActive(true);
        }
        if (isShopRoom)
        {
            shopRoomTemplate.SetActive(true);
            shopTileSet.SetActive(true);
        }
    }
}
