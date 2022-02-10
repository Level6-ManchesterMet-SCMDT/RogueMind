using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreen; // canvas holding the loading screen
    public Slider slider; // the loading bar slider
    public Animator LoadBar;// the animator for the slider
    public float loadBarTime;
    public Animator transition;// animator for the transition
    public void NextScene(int sceneIndex)
	{
        loadingScreen.SetActive(true);// sets the loading screen to active
        StartCoroutine(loadAsyncronously(sceneIndex));// starts to load the next scene
    }
    IEnumerator loadAsyncronously(int sceneIndex)
    {
        LoadBar.SetTrigger("Start"); // starts the loadbar animation
        yield return new WaitForSeconds(loadBarTime); // waits the amount of time for the load bar to finish
        transition.SetTrigger("Start");// starts the transition animation
        
        yield return new WaitForSeconds(1.0f); // waits for a second
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);// loads the next scene asyncronously(loads the next scene before changing to it)
        

        while (operation.isDone == false)// while the operation is not done will load the load bar(THIS IS UNFINISHED AND WILL BE USED IN THE FUTURE)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null ;
            
        }

        
        
    }

    public void ExitGame()
	{
        Application.Quit();
	}
}
