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
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
