using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject playerSpawnPoint;
    public GameObject player;
    public Animator transition;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpawnPoint = GameObject.FindGameObjectWithTag("EndRoom");
        transition = GameObject.Find("ScreenWipe").gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerSpawnPoint = GameObject.FindGameObjectWithTag("EndRoom");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("inCollider");
            
            StartCoroutine(playerTeleportTransition());
        }
    }
    IEnumerator playerTeleportTransition()
    {
       transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        player.transform.position = playerSpawnPoint.gameObject.transform.position;
        yield return new WaitForSeconds(0.4f);
        transition.SetTrigger("End");
    }
}
