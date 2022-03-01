using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PillBoxClickable : MonoBehaviour
{
    public Animator transition;
    public GameObject saveManager;
    public GameObject loadingScreen;
    public Slider slider;
    public Animator LoadBar;
    public float loadBarTime;

    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        saveManager.GetComponent<SaveManagerScript>().NextScene();
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevel(3));
        // this object was clicked - do something
        
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        LoadBar.SetTrigger("Start");
        yield return new WaitForSeconds(loadBarTime);
        transition.SetTrigger("Start");
        //loadingScreen.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelIndex);


        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;

            yield return null;

        }

        
    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
