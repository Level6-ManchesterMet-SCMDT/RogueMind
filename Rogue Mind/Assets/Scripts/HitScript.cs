using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.15f);//destroy object after 0.15 seconds
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
