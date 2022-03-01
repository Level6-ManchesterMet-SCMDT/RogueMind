using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject vendingMenu;
    void Start()
    {
        vendingMenu = GameObject.FindGameObjectWithTag("UI").gameObject.GetComponent<ShopMenu>().vendingMenu;
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
                vendingMenu.SetActive(true);
            }
        }
	}
}
