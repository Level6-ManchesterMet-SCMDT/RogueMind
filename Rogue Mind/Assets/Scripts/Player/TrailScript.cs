using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    public float destroyTime = 5;
    public List<Sprite> options;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        switch(Random.RandomRange(1,3))
        {
            case 1:
                sr.sprite = options[1];
                break;
            case 2:
                sr.sprite = options[2];
                break;
            case 3:
                sr.sprite = options[3];
                break;
        }
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
