using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform firePoint;//The transform child object where bullets are spawned
    public GameObject bulletPrefab;//the prefab of the bullet being shot

    public float bulletForce = 20f;//the force at which bullets are shot
    public int currentBullets;
    public int maxBullets;
    
    // Start is called before the first frame update
    void Start()
    {
        currentBullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//if left mouse click
        {
            if (currentBullets > 0)
            {
                Shoot();//Shoot
                currentBullets--;
            }
            else
            {
                StartCoroutine(Reload());
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }
    void Shoot()
	{
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);//Create a bullet from the prefab
        Rigidbody2D rigidBody = bullet.GetComponent<Rigidbody2D>();//save it's rigidBody
        rigidBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);//add a force based on the bulletForce Variable 
	}

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);//pause
        currentBullets = maxBullets;
    }
}
