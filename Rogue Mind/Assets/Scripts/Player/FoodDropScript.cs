using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropScript : MonoBehaviour
{
    public List<Sprite> sprites;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[Random.RandomRange(0, 2)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
