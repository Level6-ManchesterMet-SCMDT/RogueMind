using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitFloor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("leaving to main menu");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        }
    }
}
