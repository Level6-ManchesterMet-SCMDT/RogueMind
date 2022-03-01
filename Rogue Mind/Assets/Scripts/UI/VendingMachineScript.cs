using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject UI;
    void Start()
    {
        UI = GameObject.FindGameObjectWithTag("UI");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D collision)
	{
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                UI.GetComponent<ShopMenu>().OpenVending();
            }
        }
	}
}
