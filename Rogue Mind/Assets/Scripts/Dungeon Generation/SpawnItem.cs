using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnItem : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject item;
    public Animator animator;
    public DrugsData[] drugData;
    bool spawned;
    Transform camera;
    Transform cinemachineCam;
    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        cinemachineCam = GameObject.FindGameObjectWithTag("Cinemachine").transform;
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
            cinemachineCam.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
        }
        if (other.CompareTag("Rock"))
        {
            Destroy(other.gameObject);
        }
    }
}
