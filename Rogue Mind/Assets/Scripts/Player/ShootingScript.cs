using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform firePoint;//The transform child object where bullets are spawned
    public GameObject bulletPrefab;//the prefab of the bullet being shot

    public float bulletForce = 20f;//the force at which bullets are shot
    public int currentBullets;// the current bullets in the gun
    public int maxBullets;// the max number of bullets in the clip
    float shootDelay = 0;// used to delay the shots
    public float shootDelayLength = 20;//the delay inbetween shots
    public float reloadDelay = 1.0f;

    public ShootingState currentState;// the enemies state

    public DrugManagerScript modifiers;//finds the drugs modifiers


    public enum ShootingState
    {
        CanShoot,//when the player can shoot
        CantShoot,// when the player cant shoot
    }

    // Start is called before the first frame update
    void Start()
    {
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();// find the modifiers
        currentBullets = maxBullets;//set the current bullets to max bullets
    }

    void Update()
    {
        if (Input.GetMouseButton(0))//if left mouse click
        {
            if (currentBullets > 0)// if the player still has bullets
            {
                if (shootDelay <= 0)// if the shoot delay is over
                {
                    if (currentState == ShootingState.CanShoot)// if the player is in a state where they can shoot
                    {
                        Shoot();//Shoot

                    }
                }


            }
            else
            {
                currentState = ShootingState.CantShoot;// set it so the player can't shoot
                
            }

        }

        if (Input.GetKeyDown(KeyCode.R))//if R is pressed
        {
            StartCoroutine(Reload());//call reload
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(shootDelay > 0)//if shoot delay is more than 0
		{
            shootDelay--;// count it down by 1 a frame
		}
        
    }
    void Shoot()
	{
        shootDelay = shootDelayLength / modifiers.fireRateModifier;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//Create a bullet from the prefab
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();//save it's rigidBody
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);//add a force based on the bulletForce Variable 
        currentBullets--;// lower current bullets by one
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadDelay);//pause
        currentBullets = maxBullets;
        yield return new WaitForSeconds(reloadDelay);//pause
        currentState = ShootingState.CanShoot;
    }
}
