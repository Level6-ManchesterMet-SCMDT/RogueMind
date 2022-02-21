using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject menu;
    public Text roomsCleared;
    public Text enemiesKilled;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCollisionScript>().isDead)
        {
            OpenDeathScreen();
        }
    }

    void OpenDeathScreen()
    {
        menu.SetActive(true);
        roomsCleared.GetComponent<Text>().text = "Rooms Cleared: " + player.GetComponent<PlayerCollisionScript>().RoomsCleared.ToString();
        enemiesKilled.GetComponent<Text>().text = "Enemies Killed " + player.GetComponent<PlayerCollisionScript>().EnemiesKilled.ToString();
        Time.timeScale = 0;


    }
    public void ReturnToOffice()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
