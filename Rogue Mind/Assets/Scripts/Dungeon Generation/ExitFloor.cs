using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFloor : MonoBehaviour
{
    public Animator transition;// gets the transition animation
    public int floorChange; // how many floors do you need to go back
    public void Start()
    {
        transition = GameObject.Find("ScreenWipe").gameObject.GetComponent<Animator>();// finds the screen wipe object
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("leaving to main menu");
           StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - floorChange));// changes the scene

        }
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);// waits for the transition animation to finish


        SceneManager.LoadScene(levelIndex);// loads the level
    }
}
