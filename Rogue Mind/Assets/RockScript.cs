using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject player;
    public GameObject DeathParticles;
    private void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (health <= 0)
        {
            DestroyRock();
        }
    }
    void DestroyRock()
    {
        Instantiate(DeathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            health -= 1000;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
        }
        if (collision.CompareTag("Bullet"))
        {
            health -= collision.GetComponent<BulletScript>().damage;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
        }
        if (collision.CompareTag("EnemyBullet"))
        {
            health -= collision.GetComponent<BulletScript>().damage;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
        }
        if (collision.CompareTag("Melee"))
        {
            health -= player.GetComponent<MeleeScript>().damage;
            CinemachineShake.Instance.ShakeCamera(1f, 0.2f);
        }
        
    }
}
