using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] items;
    bool spawned;
    Transform camera;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&!spawned)
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
            GameObject spawnedItem = items[Random.Range(0, items.Length)];

            Instantiate(spawnedItem, spawnPoint.position, spawnPoint.rotation);
            spawned = true;
        }
    }
}
