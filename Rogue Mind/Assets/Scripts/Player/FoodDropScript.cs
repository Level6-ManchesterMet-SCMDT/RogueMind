using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDropScript : MonoBehaviour
{
    public List<Sprite> sprites;
    public List<string> audios;
    public string main;
    // Start is called before the first frame update
    void Start()
    {
        int i = Random.RandomRange(0, 2);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[i];
        main = audios[i];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
