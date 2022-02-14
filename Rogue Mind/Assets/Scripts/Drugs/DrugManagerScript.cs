using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<DrugsData> scriptables = new List<DrugsData>(); //the scriptable object assigned to this 
    private List<DrugsData> scriptablesCurrent = new List<DrugsData>(); //the scriptable object assigned to this 
    public GameObject player;

    public float healthModifier;// the list of modifiers that will be accessed globaly by other objects
    public float movementSpeedModifier;
    public float dashDistanceModifier;
    public float meleeDamageModifier;
    public float fireRateModifier;
    public float resistanceToEnemyModifier;
    public float meleeAttackRateModifier;
    public float gunDamageModifier;
    public bool chefDrug = false;
    public float bulletSpeedMod = 1;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        healthModifier = 1;//set all modifiers to 1 which means no changes
        movementSpeedModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().moveSpeed/100;
        dashDistanceModifier = 1;// set to 1 as when it is used it will be multiplied, so if it was 0 then the dash would become nothing
        meleeDamageModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().swordDamage/100;
        fireRateModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().gunRate/100;
        resistanceToEnemyModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().enemyResistance/100;
        meleeAttackRateModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().swordRate/100;
        gunDamageModifier = 1 + (float)this.gameObject.GetComponent<SaveManagerScript>().gunDamage/100;
        foreach(DrugsData i in scriptables)//add every modifier currently in effect to the modifier variables
		{
            AddEffects(i);
		}
    }
    public void AddEffects(DrugsData scriptable)// adds on each 
	{
            switch (scriptable.name)//run the associated start 
            {
                case "WindowCleaner":
                    WindowCleanerStart();
                    break;
                case "WindowChef":
                    ChefStart();
                    break;
                case "Soldier":
                    SoldierStart();
                    break;
                case "Athlete":
                    AthleteStart();
                    break;
                case "Doctor":
                    DoctorStart();
                    break;
        }
        
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
        for (int i = 0; i < scriptablesCurrent.Count; i++)// for every toy in the active toys list
        {

            switch (scriptablesCurrent[i].name)//run the associated start 
            {
                case "WindowCleaner":
                    Debug.Log("window");
                    WindowCleanerUpdate();
                    break;
                case "WindowChef":
                    ChefUpdate();
                    break;
                case "Soldier":
                    SoldierUpdate();
                    break;
                case "Athlete":
                    AthleteUpdate();
                    break;
                case "Doctor":
                    DoctorUpdate();
                    break;
            }
        }
    }
    
    public void WindowCleanerStart()
	{
        player.GetComponent<MeleeScript>().windowCleanerDrug = true;
	}
    public void WindowCleanerUpdate()
    {
        
    }
    public void ChefStart()
    {
        chefDrug = true;
    }
    public void ChefUpdate()
    {

    }
    public void SoldierStart()
    {
        player.GetComponent<ShootingScript>().reloadDelay /= 2;
        player.GetComponent<ShootingScript>().bulletForce /= 1.5f;
    }
    public void SoldierUpdate()
    {

    }
    public void AthleteStart()
	{
        player.GetComponent<PlayerMovement>().dashCooldown = 0;
        player.GetComponent<PlayerMovement>().atheleteDrug = true;
        
	}
    public void AthleteUpdate()
	{

	}

    public void DoctorStart()
    {
        player.GetComponent<PlayerCollisionScript>().doctorDrug = true;

    }
    public void DoctorUpdate()
    {

    }
}
