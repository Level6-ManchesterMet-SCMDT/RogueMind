using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomcollisionCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Col"))
        {
            collision.GetComponent<SmallCollider>().remove = true;
        }
    }
}
