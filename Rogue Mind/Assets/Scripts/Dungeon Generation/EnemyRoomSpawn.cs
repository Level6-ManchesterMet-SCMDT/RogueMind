using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoomSpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED}

    [System.Serializable]
    public class Wave
    {
        public int roundNum; // allows for multiple rounds
        public EnemyData[] enemyTypes;// holds the data for the different enemies
        public int[] count;// array for the amount of each enemy you would like to spawn
        public float spawnRate;// how quick the enemies spawn
    }

    public Wave[] waves; // an array of waves
    public Transform[] spawnPoints;// holds the spawnpoints in the room
    public int currentSp = 0;
    public GameObject enemyPrefab;// holds the enemy prefab
    public GameObject doors;// holds the doors of the room
    public GameObject exitDoor;// used for the exit door in the end room
    public GameObject player;
    public int maxAmountOf1Enemy;
    int max = -1;

    //used in the case of multiple rounds, unneeded for most rooms 
    public int nextWave = 0;
    public int round = 1;

    Transform camera;

    public float waveDelay = 1.0f;
    public float countdown;

    private float searchCountdown = .5f;
    public bool enemiesSpawned = false;
    public bool spawnEnemies = false;
    public float time = 1.4f;

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        countdown = waveDelay;
        if(spawnPoints.Length == 0)
        {
            UnityEngine.Debug.Log("SPAWN POINTS EMPTY");
        }
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].count.Length; j++)
            {
                waves[i].count[j] = Random.Range(0, maxAmountOf1Enemy- max);
                max += waves[i].count[j];
            }
        }
    }
    private void Update()
    {
        
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if (spawnEnemies)
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemiesAlive() && !enemiesSpawned)
                {
                    StartNewRound();
                }
                else { return; }
            }
            if (countdown <= 0)
            {
                if (state != SpawnState.SPAWNING && waves.Length > 0)
                {
                   StartCoroutine(SpawnWave(waves[nextWave]));
                }
            }

            else
            {
                countdown -= Time.deltaTime;
            }
        }
        if(enemiesSpawned == true)
        {
            state = SpawnState.FINISHED;
        }
        if(state== SpawnState.FINISHED)
        {
            if(player.GetComponent<PlayerCollisionScript>().doctorDrug)
			{
                player.GetComponent<PlayerCollisionScript>().inRoom = false;
			}
            spawnEnemies = false;
            doors.SetActive(false);
            if(exitDoor != null)
            {
                exitDoor.SetActive(true);
            }
            else
            {
                return;
            }
        }
      
    }
    bool EnemiesAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown<= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("no Enemies found");
                return false;
            }
            else
            {
                Debug.Log("enemies found");
            }
           
        }
       
        return true;
    }

    void StartNewRound()
    {
        round++;
        state = SpawnState.COUNTING;

        countdown = waveDelay;

        if (nextWave + 1 > waves.Length - 1)
        {
            enemiesSpawned = true;
        }
        else
        {
            nextWave++;
        }
    }
    IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemyTypes.Length; i++)
        {
            for (int j = 0; j < wave.count[i]; j++)
            {
                enemyPrefab.GetComponent<EnemyScript>().scriptable = wave.enemyTypes[i];
                SpawnEnemy(enemyPrefab);
                yield return new WaitForSeconds(wave.spawnRate);
            }
        }
        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Transform sp = spawnPoints[Random.Range(0,spawnPoints.Length)];
        Instantiate(enemy, sp.position, sp.rotation);
        Destroy(sp);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
            if (!enemiesSpawned)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    time = 0;
                    spawnEnemies = true;
                    if (doors != null)
                    {
                        doors.SetActive(true);
                        if (player.GetComponent<PlayerCollisionScript>().doctorDrug)
                        {
                            player.GetComponent<PlayerCollisionScript>().inRoom = true;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

            }
        }
    }
}
