using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShop : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject shopRoomTileset;
    public GameObject shopKeeper;
    bool spawned;
    Transform camera;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !spawned)
        {
            shopRoomTileset.SetActive(true);
            Instantiate(shopKeeper, spawnPoint.position, spawnPoint.rotation);
        }
        if (other.CompareTag("Player"))
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
        }
    }
}
