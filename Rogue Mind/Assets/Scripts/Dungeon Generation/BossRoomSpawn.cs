using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossRoomSpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED }

    [System.Serializable]
    public class Wave
    {
        public int roundNum; // allows for multiple rounds
        public BossData[] enemyTypes;// holds the data for the different boss data types
        public int[] count;// array for the amount of each enemy you would like to spawn
        public float spawnRate;// how quick the enemies spawn
    }

    public Wave[] waves;
    public Transform[] spawnPoints;
    public GameObject enemyPrefab; // holds the boss prefab
    public GameObject doors;
    public GameObject exitDoor;
    public int nextWave = 0;
    public int round = 1;
    
    Transform camera;
    Transform cinemachineCam;
    GameObject player;
    bool beenInRoom;

    public float waveDelay = 1.0f;
    public float countdown;

    private float searchCountdown = .5f;
    public bool enemiesSpawned = false;
    public bool spawnEnemies = false;
    public float time = 1.4f;

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        countdown = waveDelay;
        if (spawnPoints.Length == 0)
        {
            UnityEngine.Debug.Log("SPAWN POINTS EMPTY");
        }
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera").transform;// finds the main camera
        cinemachineCam = GameObject.FindGameObjectWithTag("Cinemachine").transform;
        if (player.GetComponent<PlayerCollisionScript>().hasKey&& !EnemiesAlive())
        {
            doors.SetActive(false);
        }
        if (!player.GetComponent<PlayerCollisionScript>().hasKey )
        {
            doors.SetActive(true);
        }
        if (spawnEnemies) // if enemies are needed to be spawned
        {
            if (state == SpawnState.WAITING)
            {
                if (!EnemiesAlive() && !enemiesSpawned)// if there are no enemies and non have been spawned
                {
                    StartNewRound();// starts a new round
                }
                else { return; }//if it is empty(used for camera position) does not give an error
            }
            if (countdown <= 0)// will spawn enemies
            {
                if (state != SpawnState.SPAWNING)
                {
                    SpawnWave(waves[nextWave]);// spawns the next wave
                }
            }
            else
            {
                countdown -= Time.deltaTime;// timer countsdown
            }
        }
        if (enemiesSpawned == true) // if all the enemies have been spawned
        {
            state = SpawnState.FINISHED;// changes the spawnstate to finished
        }
        if (state == SpawnState.FINISHED)
        {
            beenInRoom = true;
            spawnEnemies = false; // stops enemies spawning
            doors.SetActive(false);// doors reopen on the room
            if (exitDoor != null)// if there is an exit door
            {
                exitDoor.SetActive(true);//activates the exit door
            }
            else
            {
                return;// stops errors in the console
            }
        }
    }
    bool EnemiesAlive()// checks for enemies alive in the scene
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0) // every second check if any enemies are detected
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Boss") == null)
            {
                Debug.Log("no Enemies found");
                return false; // if no enemies are found return false 
            }
            else
            {
                Debug.Log("enemies found");
            }

        }

        return true; // if enemies are found
    }

    void StartNewRound()
    {
        round++;//increments the wave index
        state = SpawnState.COUNTING;// sets the state to counting down

        countdown = waveDelay;

        if (nextWave + 1 > waves.Length - 1) // if the next wave is bigger the amount of waves needed to spawn
        {
            enemiesSpawned = true;// sets all enemies spawned to true
        }
        else
        {
            nextWave++;// increments the next wave index
        }
    }
    public void SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING; // sets the state to spawning 

        for (int i = 0; i < wave.enemyTypes.Length; i++) // runs through every boss data type
        {
            for (int j = 0; j < wave.count[i]; j++) // runs through the count of every boss data type
            {
                enemyPrefab.GetComponent<BossScript>().scriptable = wave.enemyTypes[i]; // makes the boss equal the data equal the inputed value
                SpawnEnemy(enemyPrefab); // spawns an enemy 

                /*yield return new WaitForSeconds(1f / wave.spawnRate); //used for multiple spawns at a set spawnrate*/
            }
        }
        state = SpawnState.WAITING;
        //yield break;
    }
    void SpawnEnemy(GameObject enemy)
    {
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; // picks a random spawnpoint in the room
        Instantiate(enemy, sp.position, sp.rotation); // spawns an enemy
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // if the player is detected
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;// sets the cameras target to the spawner transform
            cinemachineCam.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
            cinemachineCam.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 7f;
            beenInRoom = true;
            if (!enemiesSpawned) //if no enemies are spawned
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    time = 0;// stops an infinate countdown
                    spawnEnemies = true;// means enemies have to spawn
                    if (doors != null)
                    {
                        doors.SetActive(true); // activates the doors on the room
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
