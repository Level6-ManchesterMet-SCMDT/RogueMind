using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;//Players Move Speed

    public Rigidbody2D rigidBody;//Players RigidBody2D Component
    public Camera cam;//the games camera;

    Vector2 movement;//stores player input for movement
    Vector2 mousePos;//mouse position on screen

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public GameObject drugSelectionMenu;

    bool ran = false;

    

    public PlayerState currentState;// the enemies state

    public enum PlayerState
    {
        Moving,//when the enemy is moving 
        Attacking,// when the enemy is attacking
        Stunned,//when the enemy is stunned
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.Moving;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        drugSelectionMenu = GameObject.FindGameObjectWithTag("DrugMenu");
        
    }

	
	// Update is called once per frame
	void Update()
    {
        switch(currentState)
		{
            case PlayerState.Moving:
                if (!ran)
                {
                    drugSelectionMenu.GetComponent<DrugChoiceScript>().OpenMenu();
                    ran = true;
                }
                movement.x = Input.GetAxisRaw("Horizontal");//Obtain user input for horizontal Movement 
                movement.y = Input.GetAxisRaw("Vertical");//Obtain user input for vertical Movement 

                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// sets mousePos from an on screen point to an in world point
                break;
            case PlayerState.Attacking:
                break;
		}
       
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Moving:
                rigidBody.MovePosition(rigidBody.position + movement * (moveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);//moves the player's rigidbody by it's movement vector by its speed over delta time

                Vector2 lookDir = mousePos - rigidBody.position;//Sets look direction to from the player to the mouse;
                float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

                rigidBody.rotation = angle;//sets players rotation to point at the mouse
                break;
            case PlayerState.Attacking:
                break;
        }
       
    }
}
