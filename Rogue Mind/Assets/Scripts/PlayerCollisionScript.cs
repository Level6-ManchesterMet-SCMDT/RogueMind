using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)//when something enters trigger hit box
	{
        
        if(collision.CompareTag("Enemy"))//if the collider is an enemy
		{
            health -= collision.GetComponent<EnemyScript>().damage;//reduce health by enemy damage ammount
            
            StartCoroutine(FlashCo());//run the flash co routine for I frames
            if (health <= 0)
            {
                Destroy(gameObject);//if health drops below 0 kill the player
            }
            
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
}
