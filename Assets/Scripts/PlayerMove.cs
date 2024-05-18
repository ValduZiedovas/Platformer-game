using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public GameObject Player;
    public float jumpForce = 1000f;
    public float rotationSpeed = 300f;
    bool InAir;
    bool canRotate = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(moveInput, 0, 0);
        transform.position += moveDirection * speed * Time.deltaTime;

        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!InAir)
                {
                    rb.AddForceAtPosition(Vector2.up * jumpForce, transform.position);
                    InAir = true;
                }
            }
            if (InAir)
            {
                if (canRotate)
                {
                    transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
                }

            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        InAir = false;

        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        InAir = true;
    }
}
