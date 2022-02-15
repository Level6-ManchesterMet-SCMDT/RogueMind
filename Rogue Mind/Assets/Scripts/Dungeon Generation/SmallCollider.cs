using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCollider : MonoBehaviour
{
    public GameObject thisDoor;
    //public GameObject doorTileset;
    public GameObject wallTileset;
    public bool remove = false;
    float waitTime = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (remove)
        {
            thisDoor.SetActive(true);
            wallTileset.SetActive(false);
            Destroy(gameObject, waitTime);
            
        }
    }
}
