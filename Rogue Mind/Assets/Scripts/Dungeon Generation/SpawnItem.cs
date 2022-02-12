using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject item;
    public DrugsData[] drugData;
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
            
            DrugsData drug = drugData[Random.Range(0, drugData.Length)];
            item.GetComponent<ItemPickup>().data = drug;

            Instantiate(item, spawnPoint.position, spawnPoint.rotation);
            spawned = true;
        }
        if (other.CompareTag("Player"))
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
        }
    }
}
