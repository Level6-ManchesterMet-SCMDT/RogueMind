using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysScript : MonoBehaviour
{
    public List<string> activeToys;
    public GameObject player;
    public GameObject saveManager;

    int temp1I;
    int temp2I;
    int temp3I;
    int temp4I;
    float temp1F;
    float temp2F;
    float temp3F;
    float temp4F;

    bool temp1B;
    bool temp2B;
    bool temp3B;
    bool temp4B;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void RealStart()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(saveManager.GetComponent<SaveManagerScript>().DeskToy1);
        Debug.Log(saveManager.GetComponent<SaveManagerScript>().DeskToy2);

        activeToys[0] = saveManager.GetComponent<SaveManagerScript>().DeskToy1;
        activeToys[1] = saveManager.GetComponent<SaveManagerScript>().DeskToy2;
        for (int i = 0; i < activeToys.Count; i++)
        {

            switch (activeToys[i])
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
        for (int i = 0; i < activeToys.Count; i++)
        {
            switch (activeToys[i])
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
