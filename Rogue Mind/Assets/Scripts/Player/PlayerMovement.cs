using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;//Players Move Speed
    public float activeMoveSpeed;//Players Move Speed

    public Rigidbody2D rigidBody;//Players RigidBody2D Component
    public Camera cam;//the games camera;

    Vector2 movement;//stores player input for movement
    Vector2 movementStore;//stores player input for movement
    Vector2 mousePos;//mouse position on screen
    Vector2 lookDir;
    float angle;

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public GameObject drugSelectionMenu;
    public SaveManagerScript save;//finds the drugs modifiers



    public float dashSpeed;
    public float dashLength = 0.5f;
    public float dashCooldown = 1f;

    float dashCounter, dashCoolCounter;

    public PlayerState currentState;// the enemies state

    public enum PlayerState
    {
        Moving,//when the enemy is moving 
        Attacking,// when the enemy is attacking
        Stunned,//when the enemy is stunned
        menu,
        Dashing,
    }
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
        currentState = PlayerState.menu;
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();
        drugSelectionMenu = GameObject.FindGameObjectWithTag("DrugMenu");
        dashLength *= modifiers.dashDistanceModifier;
    }

	
	// Update is called once per frame
	void Update()
    {
        switch(currentState)
		{
            case PlayerState.menu:
                drugSelectionMenu.GetComponent<DrugChoiceScript>().OpenMenu();
                currentState = PlayerState.Moving;
                break;
            case PlayerState.Moving:
                movement.x = Input.GetAxisRaw("Horizontal");//Obtain user input for horizontal Movement 
                movement.y = Input.GetAxisRaw("Vertical");//Obtain user input for vertical Movement 
                movement.Normalize();
                mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// sets mousePos from an on screen point to an in world point


                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (dashCoolCounter <= 0 && dashCounter <= 0)
                    {
                        activeMoveSpeed = dashSpeed;
                        movementStore = movement;
                        //rigidBody.AddForce(new Vector2(dashSpeed * movement.x * Time.deltaTime, dashSpeed * movement.y * Time.deltaTime));
                        //rigidBody.AddForceAtPosition(new Vector2(dashSpeed * movement.x, dashSpeed * movement.y), transform.position);
                        dashCounter = dashLength;
                        
                        currentState = PlayerState.Dashing;
                    }
                }

                
                break;
            case PlayerState.Attacking:
                break;

            
        }
        if (dashCounter > 0)
        {
            if (currentState == PlayerState.Dashing)
            {
                dashCounter -= Time.deltaTime;

                if (dashCounter <= 0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCoolCounter;

                    currentState = PlayerState.Moving;
                }
            }

        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Moving:
                rigidBody.MovePosition(rigidBody.position + movement * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);//moves the player's rigidbody by it's movement vector by its speed over delta time
                //rigidBody.velocity = activeMoveSpeed * movement * modifiers.movementSpeedModifier;
                lookDir = mousePos - rigidBody.position;//Sets look direction to from the player to the mouse;
                angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

                rigidBody.rotation = angle;//sets players rotation to point at the mouse
                break;
            case PlayerState.Dashing:

                //rigidBody.velocity = activeMoveSpeed * movementStore;
                rigidBody.MovePosition(rigidBody.position + movementStore * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);
                lookDir = mousePos - rigidBody.position;//Sets look direction to from the player to the mouse;
                angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

                rigidBody.rotation = angle;//sets players rotation to point at the mouse
                break;
            case PlayerState.Attacking:
                break;
        }
       
    }
}
