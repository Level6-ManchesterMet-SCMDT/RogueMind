using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    public int maxAmountOfRocks;
    public GameObject[] rocks;
    public List<Transform> spawnPoints;
    int currentSp;


    public void Start()
    {
        for (int i = 0; i < Random.Range(0,maxAmountOfRocks); i++)
        {
            currentSp = Random.Range(0, spawnPoints.Count);
            Transform sp = spawnPoints[currentSp];
            Instantiate(rocks[Random.Range(0,rocks.Length)], sp.position, sp.rotation);
            spawnPoints.Remove(sp);
        }
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Destroy(spawnPoints[i].gameObject);
        }
        spawnPoints.Clear();
        
    }

}
