using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float xOffset;
    public float yOffset;
    public float smoothSpeed = 0.125f; // The speed at which the camera follows the player
    public Vector3 offset; // The offset from the player

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10) + new Vector3(xOffset, yOffset, -10);  
    }


    /*
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }*/
}
