using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    //IFrames Flash Variables
    public Color flashColor;//the colour it flashes to
    public Color regularColor;//the colour it returns to 
    public float flashDuration;//the duration of each flash
    public int numberOfFlashes;// the number of flashes after getting hit
    public Collider2D triggerCollider;// the players trigger collider hitbox
    public SpriteRenderer spriteRenderer;// the sprite renderer

    public float health;//the players health
    public float Maxhealth;//the players health
    public int Dopamine;

    public GameObject healthBar;// the healthbar for the player

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public SaveManagerScript save;//finds the drugs modifiers

    public bool doctorDrug = false;
    public bool inRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        //Dopamine = 0;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");//set the health bar
        health = Maxhealth;//set max health
        healthBar.GetComponent<HealthBarScirpt>().SetMaxHealth(Maxhealth);
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        save = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<SaveManagerScript>();
        Maxhealth *= modifiers.healthModifier;
    }

    // Update is called once per frame 
    void Update()
    {
        if(doctorDrug && inRoom)
		{
            TakeDamage(Maxhealth * 0.0001f);
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)//when something enters trigger hit box
	{
        if(this.gameObject.GetComponent<PlayerMovement>().currentState != PlayerMovement.PlayerState.Dashing)
		{
            if (collision.CompareTag("Enemy"))//if the collider is an enemy
            {
                TakeDamage(collision.GetComponent<EnemyScript>().damage * modifiers.resistanceToEnemyModifier);//reduce health by enemy damage ammount

                StartCoroutine(FlashCo());//run the flash co routine for I frames
            }
            if (collision.CompareTag("Boss"))//if the collider is an Boss
            {
                TakeDamage(collision.GetComponent<BossScript>().damage * modifiers.resistanceToEnemyModifier);//reduce health by Boss damage ammount

                StartCoroutine(FlashCo());//run the flash co routine for I frames
            }
            if (collision.CompareTag("EnemyBullet"))//if the collider is an enemy bullet
            {
                TakeDamage(collision.GetComponent<BulletScript>().damage * modifiers.resistanceToEnemyModifier);//reduce health by enemy damage ammount
                Destroy(collision.gameObject);//destreoy the bullet
                StartCoroutine(FlashCo());//run the flash co routine for I frames
            }
        }
        
        if (collision.CompareTag("DopamineDrop"))//if the collider is a dopamine drop
        {
            Dopamine++;//increase the dopamine count
            Destroy(collision.gameObject);//destroy the dopamine drop
            
        }
        if (collision.CompareTag("FoodDrop"))//if the collider is a dopamine drop
        {
            HealDamage(25);
            Destroy(collision.gameObject);//destroy the dopamine drop

        }


    }
	private IEnumerator FlashCo()// used for Iframes and flashing
	{
        int temp = 0;
        triggerCollider.enabled = false;// turn off the hitbox to prevent getting hit each frame in contact
        while(temp<numberOfFlashes)// as long as there are more flashes to do
		{
            spriteRenderer.color = flashColor;// set the sprite the flash colour
            yield return new WaitForSeconds(flashDuration);//wait the duration
            spriteRenderer.color = regularColor;//set the sprite the normal colour
            yield return new WaitForSeconds(flashDuration);//wait the duration
            temp++;//increase the count in the loop by 1

        }
        triggerCollider.enabled = true;// turn the hitbox back on
	}

    void TakeDamage(float damage)//used for taking damage
	{
        health -= damage;
        //ScreenShakeController.instance.StartShake(.01f, 1f);
        healthBar.GetComponent<HealthBarScirpt>().SetHealth(health);//update health bar
        DeathCheck();
    }

    void DeathCheck()//check if player has died
	{
        if (health <= 0)
        { 
            save.cash += 10;//increase the ammount of cash
            save.NextScene();//save all changed data to the save file
            SceneManager.LoadScene(0);//load the desk hub scene
            Destroy(gameObject);//if health drops below 0 kill the player
        }
    }
    public void HealDamage(float heal)//used for healing
	{
        health += heal;// add health to the health variable
        if(health > Maxhealth)
		{
            health = Maxhealth;//if it has gone over max health then just set it to max health
		}
        healthBar.GetComponent<HealthBarScirpt>().SetHealth(health);//update health bar
    }
}
