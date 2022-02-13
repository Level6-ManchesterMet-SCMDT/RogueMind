using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public DrugsData data;
    public DrugManagerScript drugManager;
    public SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        drugManager = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        renderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (data.sprite != null)// if there is a sprite then set it otherwise it sticks with the prefabs default
        {
            renderer.sprite = data.sprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            drugManager.AddEffects(data);
            Destroy(gameObject);
        }
    }
}
