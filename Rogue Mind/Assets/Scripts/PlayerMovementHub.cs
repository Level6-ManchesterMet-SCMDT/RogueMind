using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementHub : MonoBehaviour
{

    public float moveSpeed = 5.0f;//Players Move Speed

    public Rigidbody2D rigidBody;//Players RigidBody2D Component
    public Camera cam;//the games camera;
    public GameObject gymMenu;
    public GameObject deskMenu;

    public Animator transition;

    Vector2 movement;//stores player input for movement
    Vector2 mousePos;//mouse position on screen
    // Start is called before the first frame update
    void Start()
    {
        
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
       
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//Obtain user input for horizontal Movement 
        movement.y = Input.GetAxisRaw("Vertical");//Obtain user input for vertical Movement 

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// sets mousePos from an on screen point to an in world point

        
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed  * Time.fixedDeltaTime);//moves the player's rigidbody by it's movement vector by its speed over delta time

        Vector2 lookDir = mousePos - rigidBody.position;//Sets look direction to from the player to the mouse;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;//sets the lookDir vec 2 to a rotation

        rigidBody.rotation = angle;//sets players rotation to point at the mouse
    }
    private void OnTriggerStay2D(Collider2D collision)//when in a hitbox
    {
        Debug.Log("in a hitbox");
        if (Input.GetKeyDown(KeyCode.E))//if the player hits e
        {
            Debug.Log("hit e");
            switch (collision.gameObject.tag)// depending on which box they are in
			{
                case "Desk":
                    Debug.Log("was desk");
                        deskMenu.SetActive(true);//ser the menu to active
                    break;
                case "Gym":
                        gymMenu.SetActive(true);
                    break;
                case "Play":
                    StartCoroutine(LoadLevel(2));
                    break;
            }

        }
    }
	private void OnTriggerExit2D(Collider2D collision)// deactive menus when player walks away from hitbox
	{
        deskMenu.SetActive(false);
        gymMenu.SetActive(false);
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.0f);


        SceneManager.LoadScene(levelIndex);
    }
}
