using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnShop : MonoBehaviour
{
    public Transform spawnPoint;// the shopkeepers spawnpoint
    //public GameObject shopRoomTileset; // used to activate the new tileset on a shop room
    public GameObject shopKeeper;// holds the shopkeeper
    public bool spawned;// checks to see if the shopkeeper has been spawned, stops repeated shopkeepers spawning on entry
    Transform camera;
    public Transform cinemachineCam;
    
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;// finds the main camera
        
    }
    private void Update()
    {
        cinemachineCam = GameObject.FindGameObjectWithTag("Cinemachine").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !spawned)
        {
            //shopRoomTileset.SetActive(true);// sets the tileset to active
            Instantiate(shopKeeper, spawnPoint.position, spawnPoint.rotation);// activates the shopkeeper and his ai
            spawned = true;
        }
        if (other.CompareTag("Player"))
        {
            cinemachineCam.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;// changes the cameras position
            
        }
        if (other.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
        }
    }
}
