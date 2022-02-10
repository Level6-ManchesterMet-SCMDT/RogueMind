using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;// used to store the players transform
    public Vector3 offset;// an offset to be used if needed
    public float smoothSpeed = 0.125f;
    public bool shaking = false;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            return;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;// moves the position of the camera to the position of the target smoothly
    }
}
