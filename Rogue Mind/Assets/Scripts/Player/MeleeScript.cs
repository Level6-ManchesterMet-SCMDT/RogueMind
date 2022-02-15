using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeScript : MonoBehaviour
{ //https://www.youtube.com/watch?v=gHaJUNiItmQ&ab_channel=DanCS

    public GameObject hit1Prefab;//The Prefabs for each sword Slash
    public GameObject hit2Prefab;
    public GameObject hit3Prefab;
    public GameObject windowCleanerHitPrefab;

    public Transform hitPoint;//The transform child object where the slashes will spawn

    public float damage = 1f;//the damage of the bullet

    //public float coolDownTime;
    //public float nextFireTime = 0f;
    public static int numberOfClicks = 0;//counts the number of clicks currently within the combo time
    public float lastClickedTime = 0f;//stores last time of click
    public float maxComboDelay;//the ammount of time before the combo resets
    public float hitDelay;
    public float currentDelay = 0;

    public float secondHitModifier = 2.0f;// the modifier on damage for the second melee hit
    public float thirdHitModifier = 3.0f;// the modifier on damage for the third melee hit

    float initialDamage;// the damage value that the attack initialy has

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public bool windowCleanerDrug = false;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        initialDamage = damage;// sets the damage to initial attack as we will be changing damage , but want to maintain what was originaly entered
        hitDelay /= modifiers.meleeAttackRateModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentDelay >= 0)
		{
            currentDelay--;
		}
        else
		{
            if (Time.time - lastClickedTime > maxComboDelay)// if no click has been entered before the ammount of time to end the combo happens
            {
                
                numberOfClicks = 0;
                damage = initialDamage * modifiers.meleeDamageModifier;//sets damage back to 1 for the first hit
            }
            if (Input.GetMouseButtonDown(1))//if right mouse button clicked
            {
                OnClick();//Run the onClick function
            }
        }
       
    }

    void OnClick()
	{
        if(!windowCleanerDrug)
		{
            lastClickedTime = Time.time;//sets the lastest time of click
            numberOfClicks++;//increase the number of clicks in current combo
            if (numberOfClicks == 1)// if 1 click
            {
                this.gameObject.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Attacking;
                soundManager.PlaySound("Sword");
                //hit 1
                GameObject hitBox = Instantiate(hit1Prefab, hitPoint.position, hitPoint.rotation);//spawn first hitbox
            }
            numberOfClicks = Mathf.Clamp(numberOfClicks, 0, 3);//clamps the number of clicks so it doesnt exceed 3
            if (numberOfClicks == 2)//if 2 clicks
            {
                this.gameObject.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Attacking;
                soundManager.PlaySound("Sword");
                //second hit
                damage = (initialDamage * secondHitModifier) * modifiers.meleeDamageModifier;//doubles damage value
                GameObject hitBox = Instantiate(hit2Prefab, hitPoint.position, hitPoint.rotation);//spawn second hitbox
            }
            if (numberOfClicks == 3)//if 3 clicks
            {
                currentDelay = hitDelay;
                //third hit
                this.gameObject.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Attacking;
                soundManager.PlaySound("Sword");
                damage = (initialDamage * thirdHitModifier) * modifiers.meleeDamageModifier;//tripples damage value
                GameObject hitBox = Instantiate(hit3Prefab, hitPoint.position, hitPoint.rotation);//spawn third hitbox

                numberOfClicks = 0;//reset number of clicks 

                //COMMENT OUT LINE ABOVE AND MATHF.CLAMP LINE FOR A MORE RESTRICTIVE MELEE ATTACK
            }
        }
        else
		{
            currentDelay = hitDelay;
            //third hit
            this.gameObject.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.Attacking;
            soundManager.PlaySound("Sword");
            damage = initialDamage * modifiers.meleeDamageModifier;//tripples damage value
            GameObject hitBox = Instantiate(windowCleanerHitPrefab, hitPoint.position, hitPoint.rotation);//spawn third hitbox

            numberOfClicks = 0;//reset number of clicks 
        }
        

    }
}
