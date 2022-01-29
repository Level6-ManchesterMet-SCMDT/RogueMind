using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private List<DrugsData> scriptables = new List<DrugsData>(); //the scriptable object assigned to this 

    public float healthModifier = 1;
    public float movementSpeedModifier = 1;
    public float dashDistanceModifier = 1;
    public float meleeDamageModifier = 1;
    public float fireRateModifier = 1;
    public float resistanceToEnemyModifier = 1;


    void Start()
    {
        healthModifier = 1;
        movementSpeedModifier = 1;
        dashDistanceModifier = 1;
        meleeDamageModifier = 1;
        fireRateModifier = 1;
        resistanceToEnemyModifier = 1;
        foreach(DrugsData i in scriptables)
		{
            AddEffects(i);
		}
    }
    public void AddEffects(DrugsData scriptable)
	{
        scriptables.Add(scriptable);
        healthModifier += scriptable.healthPercentage;
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
