using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidWallCheck : MonoBehaviour
{
    //IN PROGRESS -- will be commented when finished

    public GameObject doorTileMap;
    public GameObject wallcollider;
    public float waitTime = 2f;
    float wt = 1.5f;
    public int collisions = 0;

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0 && collisions<= 0)
        {
            wallcollider.SetActive(true);
            doorTileMap.SetActive(true);
            //Destroy(gameObject, wt);
        }
        else if (collisions >= 0)
        {
            wallcollider.SetActive(false);
            doorTileMap.SetActive(false);
        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        collisions++;
        if(other.tag != "emptyChecker")
        {
            wallcollider.SetActive(true);
            doorTileMap.SetActive(true);
        }
        else if (other.CompareTag("Col"))
        {
            wallcollider.SetActive(true);
            doorTileMap.SetActive(true);
        }
    }
}
