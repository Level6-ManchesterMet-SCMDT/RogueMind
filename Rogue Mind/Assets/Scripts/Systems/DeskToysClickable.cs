using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskToysClickable : MonoBehaviour
{
    public GameObject mainMenu;// the menu it is associated with
    public GameObject otherMenu;// the other menu

    public Sprite sprite1;// the sprite associated with the non hovered over icon
    public string sound;
    public Sprite sprite2;// the sprite associated with the hovered over icon
    public SoundManager soundManager;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        
        otherMenu.SetActive(false);// turn off the other menu
        mainMenu.SetActive(true);//turn on this menu
    }

	private void OnMouseEnter()
	{
        soundManager.PlaySound(sound);
    }
	void OnMouseOver()
    {
        
        //If your mouse hovers over the GameObject with the script attached, output this message
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;// if mouse over then second sprite
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");// if mouse off then first sprite
    }
}
