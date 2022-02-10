using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;
    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); // finds the room templates 
        templates.rooms.Add(this.gameObject); // adds the room to the room list
        if(this.gameObject.tag == "EndCap")
        {
            templates.endRooms.Add(this.gameObject); // adds the room to the end rooms list
        }
    }
}
