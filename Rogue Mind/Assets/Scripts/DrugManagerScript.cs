using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DrugsData> scriptables = new List<DrugsData>(); //the scriptable object assigned to this 
    private List<DrugsData> scriptablesCurrent = new List<DrugsData>(); //the scriptable object assigned to this 

    public float healthModifier;
    public float movementSpeedModifier;
    public float dashDistanceModifier;
    public float meleeDamageModifier;
    public float fireRateModifier;
    public float resistanceToEnemyModifier;


    void Start()
    {
        healthModifier = 1;//set all modifiers to 1 which means no changes
        movementSpeedModifier = 1;
        dashDistanceModifier = 1;
        meleeDamageModifier = 1;
        fireRateModifier = 1;
        resistanceToEnemyModifier = 1;
        foreach(DrugsData i in scriptables)//add every modifier currently in effect to the modifier variables
		{
            AddEffects(i);
		}
    }
    public void AddEffects(DrugsData scriptable)// adds on each 
	{
        scriptablesCurrent.Add(scriptable);// add to current list of in effect modifiers
        healthModifier += scriptable.healthPercentage;//add all modifers
        movementSpeedModifier += scriptable.movementSpeedPercentage;
        movementSpeedModifier += scriptable.movementSpeedPercentage;
        dashDistanceModifier += scriptable.dashDistancePercentage;
        meleeDamageModifier += scriptable.meleeDamagePercentage;
        fireRateModifier += scriptable.fireRatePercentage;
        resistanceToEnemyModifier += scriptable.resistanceToEnemyDamage;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
