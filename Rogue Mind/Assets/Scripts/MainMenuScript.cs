using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void NextScene(int sceneIndex)
	{

        StartCoroutine(loadAsyncronously(sceneIndex));
    }
    IEnumerator loadAsyncronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;
        }
    }

    public void ExitGame()
	{
        Application.Quit();
	}
}
