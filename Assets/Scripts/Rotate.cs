using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float jumpForce = 10f;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool isRotating = false;
    private float targetRotation;
    private float rotationSpeed = 360f; // Degrees per second

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(moveInput, 0, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        CheckGrounded();

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (isGrounded && moveInput != 0 && !isRotating)
        {
            RotateCube();
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
