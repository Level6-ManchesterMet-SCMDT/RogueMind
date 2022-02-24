using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5.0f;//Players Move Speed
    public float activeMoveSpeed;//Players Move Speed
    public float reducedSpeed;//Players Move Speed

    public Rigidbody2D rigidBody;//Players RigidBody2D Component
    public Camera cam;//the games camera;

    Vector2 movement;//stores player input for movement
    Vector2 movementStore;//stores player input for movement
    Vector2 mousePos;//mouse position on screen
    public Vector2 lookDir;// the direction the player is looking in
    float angle;// an angle used for setting the players look direction

    public DrugManagerScript modifiers;//finds the drugs modifiers
    public GameObject drugSelectionMenu;
    public SaveManagerScript save;//finds the drugs modifiers

    public Transform arm;
    Vector3 armScale;
    public ArmRotation rotate;
    public GameObject lights;

    public Transform bodyGFX;
    public Animator bodyAnim;
    Vector3 bodyScale;
    
    public Transform legsGFX;
    public Animator legsAnim;
    Vector3 LegsScale;


    public float dashSpeed;// the speed of a dash
    public float dashLength = 0.5f;// the length of a dash 
    public float dashCooldown = 1f;// the cool down between dashes
    public float activeDashCooldown;// the cool down between dashes
    public bool atheleteDrug = false;// the cool down between dashes
    public bool killedEnemy = true;// the cool down between dashes
    public int dashCount = 0;// the cool down between dashes
    public GameObject trail;
    public bool janitorDrug = false;

    public bool isLeft;
    public bool isRight;

    float dashCounter, dashCoolCounter;

    public PlayerState currentState;// the enemies state

    public SoundManager soundManager;

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
        soundManager = GameObject.FindGameObjectWithTag("SFX").GetComponent<SoundManager>();
        activeMoveSpeed = moveSpeed;// setting the active movespeed to that set in the inspector
        currentState = PlayerState.Moving;// set the players state to menu, just to get the initial drug menu to show
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();// find the camera
        modifiers = GameObject.FindGameObjectWithTag("DrugManager").GetComponent<DrugManagerScript>();// find the modifiers
        drugSelectionMenu = GameObject.FindGameObjectWithTag("DrugMenu");//finds the drug selection menu
        activeDashCooldown = 0;//sets the dash cool down to nothing
        reducedSpeed = moveSpeed / 2;
        
    }

	
	// Update is called once per frame
	void Update()
    {
        switch(currentState)
		{
            case PlayerState.menu:
                
                
                break;
            case PlayerState.Moving:
                movement.x = Input.GetAxisRaw("Horizontal");//Obtain user input for horizontal Movement 
                movement.y = Input.GetAxisRaw("Vertical");//Obtain user input for vertical Movement 
                movement.Normalize();

                legsAnim.SetFloat("Speed", movement.sqrMagnitude);
                bodyAnim.SetFloat("Speed", movement.sqrMagnitude);

                arm.GetComponent<ArmRotation>().movement.x = Input.GetAxisRaw("Horizontal");//Obtain user input for horizontal Movement 
                arm.GetComponent<ArmRotation>().movement.y = Input.GetAxisRaw("Vertical");//Obtain user input for vertical Movement 
                arm.GetComponent<ArmRotation>().movement.Normalize();
                arm.GetComponent<ArmRotation>().mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// sets mousePos from an on screen point to an in world point

              

                if (Input.GetKeyDown(KeyCode.LeftShift))//if the player hits "E"
                {
                    if (dashCoolCounter <= 0 && dashCounter <= 0)// If the dash cool down is 0
                    {
                        if (!atheleteDrug)
                        {
                            soundManager.PlaySound("Dash");
                            activeMoveSpeed = dashSpeed;// start the dash
                            movementStore = movement;// save the current movement axis so the dash is only in 1 direction
                                                     //rigidBody.AddForce(new Vector2(dashSpeed * movement.x * Time.deltaTime, dashSpeed * movement.y * Time.deltaTime));
                                                     //rigidBody.AddForceAtPosition(new Vector2(dashSpeed * movement.x, dashSpeed * movement.y), transform.position);
                            dashCounter = dashLength * modifiers.dashDistanceModifier;// set the length of the dash to that of dash length by the current modidfer
                            
                            currentState = PlayerState.Dashing;//set the players state to dashing
                            
                        }
                        else if (killedEnemy)
						{

                            activeMoveSpeed = dashSpeed;// start the dash
                            movementStore = movement;// save the current movement axis so the dash is only in 1 direction
                                                     //rigidBody.AddForce(new Vector2(dashSpeed * movement.x * Time.deltaTime, dashSpeed * movement.y * Time.deltaTime));
                                                     //rigidBody.AddForceAtPosition(new Vector2(dashSpeed * movement.x, dashSpeed * movement.y), transform.position);
                            dashCounter = dashLength * modifiers.dashDistanceModifier;// set the length of the dash to that of dash length by the current modidfer

                            currentState = PlayerState.Dashing;//set the players state to dashing
                            if (dashCount == 0)
                            {
                                dashCount = 1;
                            }
                            else
                            {
                                killedEnemy = false;
                                dashCount = 0;
                            }
                        }
                       
                    }
                    
                }
                if (Input.GetAxis("Horizontal") < 0)
                {
                    bodyScale.x = -1;
                    bodyScale.y = 1;
                    bodyScale.z = 1;
                    bodyGFX.transform.localScale = bodyScale;

                    LegsScale.x = -1;
                    LegsScale.y = 1;
                    LegsScale.z = 1;
                    legsGFX.transform.localScale = LegsScale;
                    
                    armScale.x = -1;
                    armScale.y = 1;
                    armScale.z = 1;
                    arm.transform.localScale = armScale;
                    isLeft = true;
                    isRight = false;
                }
                if (Input.GetAxis("Horizontal") > 0)
                {
                    bodyScale.x = 1;
                    bodyScale.y = 1;
                    bodyScale.z = 1;
                    bodyGFX.transform.localScale = bodyScale;

                    LegsScale.x = 1;
                    LegsScale.y = 1;
                    LegsScale.z = 1;
                    legsGFX.transform.localScale = LegsScale;


                    armScale.x = 1;
                    armScale.y = 1;
                    armScale.z = 1;
                    arm.transform.localScale = armScale;
                    isLeft = false;
                    isRight = true;
                }
                if(arm.GetComponent<ArmRotation>().lookDir.x < 0)
                {
                    
                    
                }
                if (arm.GetComponent<ArmRotation>().lookDir.x > 0)
                {
                   
                   
                }


                break;
            case PlayerState.Attacking:
                break;
            case PlayerState.Dashing:
                if(janitorDrug)
				{
                    Instantiate(trail, transform.position,transform.rotation);
				}
                break;


        }
        if (dashCounter > 0)// if dash is in progress
        {
            if (currentState == PlayerState.Dashing)//if the players state is dashing
            {
                dashCounter -= Time.deltaTime;// count down the dash counter

                if (dashCounter <= 0)// once it's 0
                {
                    activeMoveSpeed = moveSpeed;// stop the dash
                    activeDashCooldown = dashCoolCounter;//set the cooldown

                    currentState = PlayerState.Moving;//back to moving state
                }
            }

        }

        if (activeDashCooldown > 0)// if in cool down
        {
            dashCoolCounter -= Time.deltaTime;//count down
        }

    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case PlayerState.Moving:
                rigidBody.MovePosition(rigidBody.position + movement * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);
                arm.GetComponent<ArmRotation>().rigidBody.MovePosition(rigidBody.position + movement * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);//moves the player's rigidbody by it's movement vector by its speed over delta time
                //rigidBody.velocity = activeMoveSpeed * movement * modifiers.movementSpeedModifier;
                arm.GetComponent<ArmRotation>().lookDir = arm.GetComponent<ArmRotation>().mousePos - arm.GetComponent<ArmRotation>().rigidBody.position;//Sets look direction to from the player to the mouse;
                arm.GetComponent<ArmRotation>().angle = Mathf.Atan2(arm.GetComponent<ArmRotation>().lookDir.y, arm.GetComponent<ArmRotation>().lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

                arm.GetComponent<ArmRotation>().rigidBody.rotation = arm.GetComponent<ArmRotation>().angle;//sets players rotation to point at the mouse
                break;
            case PlayerState.Dashing:

                //rigidBody.velocity = activeMoveSpeed * movementStore;
                rigidBody.MovePosition(rigidBody.position + movementStore * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);
                arm.GetComponent<ArmRotation>().rigidBody.MovePosition(rigidBody.position + movementStore * (activeMoveSpeed * modifiers.movementSpeedModifier) * Time.fixedDeltaTime);//moves the player's rigidbody by it's movement vector by its speed over delta time
                arm.GetComponent<ArmRotation>().lookDir = arm.GetComponent<ArmRotation>().mousePos - arm.GetComponent<ArmRotation>().rigidBody.position;//Sets look direction to from the player to the mouse;
                arm.GetComponent<ArmRotation>().angle = Mathf.Atan2(arm.GetComponent<ArmRotation>().lookDir.y, arm.GetComponent<ArmRotation>().lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

                arm.GetComponent<ArmRotation>().rigidBody.rotation = arm.GetComponent<ArmRotation>().angle;//sets players rotation to point at the mouse
                break;
            case PlayerState.Attacking:
                break;
        }
       
    }
}
