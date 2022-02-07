using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Animator LoadBar;
    public float loadBarTime;
    public Animator transition;
    public void NextScene(int sceneIndex)
	{
        loadingScreen.SetActive(true);
        StartCoroutine(loadAsyncronously(sceneIndex));
    }
    IEnumerator loadAsyncronously(int sceneIndex)
    {
        LoadBar.SetTrigger("Start");
        yield return new WaitForSeconds(loadBarTime);
        transition.SetTrigger("Start");
        
        yield return new WaitForSeconds(1.0f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        

        while (operation.isDone == false)
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
