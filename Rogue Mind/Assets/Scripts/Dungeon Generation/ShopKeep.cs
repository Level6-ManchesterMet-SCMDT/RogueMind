using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeep : MonoBehaviour
{
    public GameObject drugsMenu;
    public GameObject player;
    public SoundManager soundManager;
    // Start is called before the first frame update
    private void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        drugsMenu = GameObject.FindGameObjectWithTag("UI");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Detected");
            player = other.gameObject;
            if (Input.GetKeyDown(KeyCode.F))
            {
                drugsMenu.GetComponent<ShopMenu>().OpenMenu();
               
            }
        }
    }
}
