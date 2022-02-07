using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isEndRoom = false;
    public bool isItemRoom = false;
    public bool isShopRoom = false;
    public GameObject endRoomTemplate;
    public GameObject itemRoomTemplate;

    // Update is called once per frame
    void Update()
    {
        if (isEndRoom)
        {
            endRoomTemplate.SetActive(true);
        }
        if (isItemRoom)
        {
            itemRoomTemplate.SetActive(true);
        }
    }
}
