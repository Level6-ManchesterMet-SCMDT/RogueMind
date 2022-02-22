using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyRoomSpawn : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING, FINISHED}

    [System.Serializable]
    public class Wave
    {
        public int roundNum; // allows for multiple rounds
        public WaveData[] waveData;
        public List<EnemyData>  enemyTypes;// holds the data for the different enemies
        public List<int> count;// array for the amount of each enemy you would like to spawn
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
    int CurrentWaveType;

    //used in the case of multiple rounds, unneeded for most rooms 
    public int nextWave = 0;
    public int round = 1;

    Transform camera;
    Transform cinemachineCam;

    public float waveDelay = 1.0f;
    public float countdown;

    bool RoomCleared = false;

    private float searchCountdown = .5f;
    public bool enemiesSpawned = false;
    public bool spawnEnemies = false;
    public float time = 1.4f;
    public SoundManager soundManager;

    public SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        countdown = waveDelay;
        if(spawnPoints.Length == 0)
        {
            UnityEngine.Debug.Log("SPAWN POINTS EMPTY");
        }
        currentSp = Random.Range(0, spawnPoints.Length);

        
    }
    private void Update()
    {
        cinemachineCam = GameObject.FindGameObjectWithTag("Cinemachine").transform;
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
            if (!RoomCleared)
            {
                player.GetComponent<PlayerCollisionScript>().RoomsCleared += 1;
                RoomCleared = true;
            }
            //soundManager.PlaySound("DoorOpen");

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
        wave.enemyTypes.Clear();
        wave.count.Clear();

        CurrentWaveType = Random.Range(0, wave.waveData.Length);
        for (int i = 0; i < wave.waveData.Length; i++)
        {
            if(i== CurrentWaveType)
            {
                for (int j = 0; j < wave.waveData[i].enemyData.Length; j++)
                {
                    wave.enemyTypes.Add(wave.waveData[i].enemyData[j]);
                    wave.count.Add(wave.waveData[i].amount[j]);
                }
            }
        }

        for(int i = 0; i < wave.enemyTypes.Count; i++)
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
        Transform sp = spawnPoints[currentSp];
        Instantiate(enemy, sp.position, sp.rotation);
        currentSp++;
        if (currentSp> spawnPoints.Length - 1)
        {
            currentSp = 0;
        }
        
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            camera.GetComponent<CameraScript>().target = this.gameObject.transform;
            cinemachineCam.GetComponent<CinemachineVirtualCamera>().Follow = this.gameObject.transform;
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
                        //soundManager.PlaySound("DoorClose");
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
