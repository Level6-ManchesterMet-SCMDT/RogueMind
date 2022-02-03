using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFloor : MonoBehaviour
{
    public Animator transition;
    public int floorChange;
    public void Start()
    {
        transition = GameObject.Find("ScreenWipe").gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("leaving to main menu");
           StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - floorChange));

        }
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);


        SceneManager.LoadScene(levelIndex);
    }
}
