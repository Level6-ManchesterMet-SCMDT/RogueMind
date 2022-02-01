using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForMain : MonoBehaviour
{
    public GameObject sps;
    public float loadTime;
    bool spawned = false;

    private void Update()
    {
        loadTime -= Time.deltaTime;
        if (loadTime <= 0)
        {
            loadTime = 0;
            if (!spawned)
            {
                Spawn();
                spawned = true;
            }

        }

    }

    void Spawn()
    {
        sps.SetActive(true);
    }
}
