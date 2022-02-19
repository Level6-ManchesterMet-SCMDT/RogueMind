using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(enemy != null)
		{
            transform.position = (enemy.transform.position - new Vector3(0,0.5f,0));
		}
    }
}
