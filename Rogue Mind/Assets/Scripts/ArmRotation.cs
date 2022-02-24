 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public Vector2 mousePos;//mouse position on screen
    public Vector2 lookDir;// the direction the player is looking in
    public Vector2 movement;
    public float angle;// an angle used for setting the players look direction
    public Rigidbody2D rigidBody;
    public Camera cam;
}
