using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysClickable : MonoBehaviour
{
    public GameObject deskMenu;
    public GameObject otherMenu;

    public Sprite sprite1;
    public Sprite sprite2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        otherMenu.SetActive(false);
        deskMenu.SetActive(true);
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
