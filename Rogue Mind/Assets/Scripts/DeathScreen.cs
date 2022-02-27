using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DeathScreen : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject menu;
    public bool paused;
    public Text roomsCleared;
    public Text enemiesKilled;
    public Animator deathTransition;
    public AudioMixer mainMixer;
    //public Animator pauseMenuTransition;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        deathTransition = menu.GetComponent<Animator>();
        //pauseMenuTransition = pauseMenu.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCollisionScript>().isDead)
        {
            OpenDeathScreen();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void OpenDeathScreen()
    {
        StartCoroutine(OpenTransition());
 
    }
    public void ReturnToOffice()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        paused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }
    public void Resume()
    {
        paused = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
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
    IEnumerator pauseMenuOpen()
    {
        pauseMenu.SetActive(true);
        //pauseMenuTransition.SetTrigger("Pause");
        
        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 0f;

    }
    IEnumerator pauseMenuClose()
    {
        pauseMenu.SetActive(true);
        //pauseMenuTransition.SetTrigger("Pause");

        yield return new WaitForSeconds(1.0f);
        Time.timeScale = 1f;
    }

    public void SetFullScreen(bool isFullscreen)
	{
        Screen.fullScreen = isFullscreen;
	}

    public void SetVolume(Slider slider)
	{
        
        mainMixer.SetFloat("volume", slider.value);
        

    }
}
