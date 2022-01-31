using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("SpawnPoint"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("WaveSpawner"))
        {
            Destroy(other.gameObject);
        }
    }
}
