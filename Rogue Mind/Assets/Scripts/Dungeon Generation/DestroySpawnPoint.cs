using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("SpawnPoint"))
        {
            other.GetComponent<RoomSpawner>().spawned = true;
        }
        if (other.CompareTag("WaveSpawner")&& this.tag != "Destroyer")
        {
            Destroy(other.gameObject);
        }
    }
}
