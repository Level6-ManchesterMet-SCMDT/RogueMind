using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public bool isEndRoom = false;
    public GameObject endRoomTemplate;

    // Update is called once per frame
    void Update()
    {
        if (isEndRoom)
        {
            endRoomTemplate.SetActive(true);
        }
    }
}
