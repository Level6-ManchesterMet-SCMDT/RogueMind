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
    public float shootDelay = 0;// used to delay the shots
    public float shootDelayLength = 20;//the delay inbetween shots
    public float reloadDelay = 1.0f;

    public ShootingState currentState;// the enemies state

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public SoundManager soundManager;


    public enum ShootingState
    {
        CanShoot,//when the player can shoot
        CantShoot,// when the player cant shoot
    }

    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
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
            if(currentState == ShootingState.CanShoot)
			{
                currentState = ShootingState.CantShoot;
                StartCoroutine(Reload());//call reload
            }
            
        }
        if(Input.GetMouseButtonUp(0) && currentBullets == 0)
		{
            currentState = ShootingState.CantShoot;
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
        CinemachineShake.Instance.ShakeCamera(1f, .1f);
        soundManager.PlaySound("Gun");
        shootDelay = shootDelayLength / modifiers.fireRateModifier;
        //Vector3 offset = firePoint.up + new Vector3(Random.RandomRange(0f,0.5f), 0, 0);
        //firePoint.up += new Vector3(Random.RandomRange(0f, 02f), 0, 0);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position , firePoint.rotation);//Create a bullet from the prefab
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();//save it's rigidBody
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);//add a force based on the bulletForce Variable 
        currentBullets--;// lower current bullets by one
    }

    private IEnumerator Reload()
    {

        for (int i = 0; i < maxBullets; i++)
        {
            yield return new WaitForSeconds(reloadDelay / maxBullets);//pause
            currentBullets++;
        }
        if(currentBullets > maxBullets)
		{
            currentBullets = maxBullets;
		}
        //yield return new WaitForSeconds(reloadDelay);//pause
        currentState = ShootingState.CanShoot;
        shootDelay = 0;
    }
}
