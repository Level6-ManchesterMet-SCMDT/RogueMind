using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public GameObject menu;
    public Text roomsCleared;
    public Text enemiesKilled;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void OpenWinScreen()
    {
        StartCoroutine(OpenTransition());

    }
    IEnumerator OpenTransition()
    {
        //transition.SetTrigger("Start");
        menu.SetActive(true);

        roomsCleared.GetComponent<Text>().text = "Rooms Cleared: " + player.GetComponent<PlayerCollisionScript>().RoomsCleared.ToString();
        enemiesKilled.GetComponent<Text>().text = "Enemies Killed " + player.GetComponent<PlayerCollisionScript>().EnemiesKilled.ToString();
        player.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0;
    }
    public void ReturnToOffice()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}