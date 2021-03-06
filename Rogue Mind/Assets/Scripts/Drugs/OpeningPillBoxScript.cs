using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningPillBoxScript : MonoBehaviour
{
    public GameObject menu;
    public GameObject player;
    public Animator transition;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        menu = GameObject.FindGameObjectWithTag("DrugMenu");//finds the drug selection menu
        player = GameObject.FindWithTag("Player");//find the player and rigid body
        transition = menu.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
            soundManager.PlaySound("MenuOpen");
            menu.GetComponent<DrugChoiceScript>().OpenMenu();
            Destroy(this.gameObject);
            transition.SetTrigger("Start");
		}
	}
}
