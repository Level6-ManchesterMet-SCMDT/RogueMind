using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysScript : MonoBehaviour
{
    public List<string> activeToys;// a list of toys currently active
    public GameObject player;// the player
    public GameObject saveManager;// the save manager

    int temp1I;// a series of integers used by Toy's AI
    int temp2I;
    int temp3I;
    int temp4I;

    float temp1F;// a series of floats used by Toy's AI
    float temp2F;
    float temp3F;
    float temp4F;

    bool temp1B;// a series of bools used by Toy's AI
    bool temp2B;
    bool temp3B;
    bool temp4B;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void RealStart()// used to be called after the save file is read
	{
        player = GameObject.FindGameObjectWithTag("Player");// find the player
        activeToys[0] = saveManager.GetComponent<SaveManagerScript>().DeskToy1;// set the active toys to be those currently in the save file
        activeToys[1] = saveManager.GetComponent<SaveManagerScript>().DeskToy2;
        for (int i = 0; i < activeToys.Count; i++)// for every toy in the active toys list
        {

            switch (activeToys[i])//run the associated start 
            {
                case "Atomic":
                    AtomicFigureStart();
                    break;
                case "Energy":
                    EnergyDrinkStart();
                    break;
                case "Plumber":
                    ThePlumberStart();
                    break;
                case "Donut":
                    PlasticDoughnutStart();
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < activeToys.Count; i++)// for every toy in the active toys list
        {
            switch (activeToys[i])//run the associated update
            {
                case "Atomic":
                    AtomicFigureUpdate();
                    break;
                case "Energy":
                    EnergyDrinkUpdate();
                    break;
                case "Plumber":
                    ThePlumberUpdate();
                    break;
                case "Donut":
                    PlasticDoughnutUpdate();
                    break;
            }
        }
    }

    void AtomicFigureStart()
    {
        temp1F = player.GetComponent<MeleeScript>().damage;
    }
    void AtomicFigureUpdate()
	{
        if(player.GetComponent<PlayerCollisionScript>().health < player.GetComponent<PlayerCollisionScript>().Maxhealth*0.35)
		{
            player.GetComponent<MeleeScript>().damage *= 2;
		}
        else
		{
            player.GetComponent<MeleeScript>().damage = temp1F;
        }
	}


    void EnergyDrinkStart()
    {
        Debug.Log("ran");
        player.GetComponent<PlayerCollisionScript>().Dopamine += 100;
    }
    void EnergyDrinkUpdate()
    {

    }


    void ThePlumberStart()
    {
        temp1B = false;
    }
    void ThePlumberUpdate()
    {
        if(player.GetComponent<PlayerCollisionScript>().health < player.GetComponent<PlayerCollisionScript>().Maxhealth * 0.5 && temp1B == false)
		{
            player.GetComponent<PlayerCollisionScript>().health = player.GetComponent<PlayerCollisionScript>().Maxhealth;
            temp1B = false;

        }
    }


    void PlasticDoughnutStart()
    {
        player.GetComponent<PlayerCollisionScript>().Maxhealth += 100;
    }
    void PlasticDoughnutUpdate()
    {

    }
}
