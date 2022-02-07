using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeep : MonoBehaviour
{
    public GameObject drugsMenu;
    // Start is called before the first frame update
    void Update()
    {
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                drugsMenu.SetActive(true);
            }
        }
    }
}
