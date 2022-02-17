using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPillBoxScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.FindGameObjectWithTag("DrugMenu");//finds the drug selection menu
        player = GameObject.FindWithTag("Player");//find the player and rigid body
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            menu.GetComponent<DrugChoiceScript>().OpenMenu();
            Destroy(this.gameObject);
		}
	}
}
