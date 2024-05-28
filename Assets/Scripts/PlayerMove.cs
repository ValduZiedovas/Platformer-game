using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private bool isRotating = false;
    private float targetRotation;
    private float rotationSpeed = 360f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGrounded();

        float moveInput = Input.GetAxisRaw("Horizontal");
        Vector3 moveDirection = new Vector3(moveInput, 0, 0);
        transform.position += moveDirection * speed * Time.deltaTime;

        if (isGrounded && Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (isRotating)
        {
            RotateCubeOverTime();
        }
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        RotateCube();
    }

    void RotateCube()
    {
        isRotating = true;
        targetRotation = transform.eulerAngles.z + 180f;
    }

    void RotateCubeOverTime()
    {
        float currentRotation = transform.eulerAngles.z;
        float newRotation = Mathf.MoveTowardsAngle(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(0, 0, newRotation);

        if (Mathf.Approximately(newRotation, targetRotation))
        {
            isRotating = false;
        }
    }
}
