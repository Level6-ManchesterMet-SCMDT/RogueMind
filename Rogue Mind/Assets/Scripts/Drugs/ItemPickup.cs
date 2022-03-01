using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public DrugsData data;
    public DrugManagerScript drugManager;
    public SpriteRenderer renderer;
    public GameObject player;
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.PlaySound("Keycard");
            player.GetComponent<PlayerCollisionScript>().hasKey = true;
            Destroy(gameObject);
        }
    }
}
