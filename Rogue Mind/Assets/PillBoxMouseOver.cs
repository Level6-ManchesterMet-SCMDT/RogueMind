using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PillBoxMouseOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite sprite1;
    public Sprite sprite2;
    public SpriteRenderer sr;
   
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    public void setSprite()
	{
        
        gameObject.GetComponent<Image>().sprite = sprite1;
	}
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseOver2()
    {
        GetComponent<Image>().sprite = sprite2;
        Debug.Log("mouseover");
    }
    public void OnMouseExit2()
    {
        GetComponent<Image>().sprite = sprite1;
        Debug.Log("mousenot");
    }
}
