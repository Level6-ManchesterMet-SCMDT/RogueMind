using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScirpt : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;//the player

    public Slider slider;// the healthbar itself

	private void Start()
	{
		
		player = GameObject.FindGameObjectWithTag("Player");//find the player	
		//set the max health
	}
	public void SetMaxHealth(float health)//sets max health
	{
		slider.maxValue = health;
        slider.value = health;
	}

    public void SetHealth(float health)//sets current slider value
	{
		slider.value = health;
	}
}
