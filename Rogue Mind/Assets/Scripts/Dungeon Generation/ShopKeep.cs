using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeep : MonoBehaviour
{
    public GameObject drugsMenu;
    // Start is called before the first frame update
    private void Start()
    {
        drugsMenu = GameObject.FindGameObjectWithTag("UI").GetComponent<ShopMenu>().menu;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                drugsMenu.SetActive(true);
            }
        }
    }
}
