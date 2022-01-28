using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerBody;

    public float moveSpeed = 2.5f;

    public float jumpSpeed = 5.0f;

    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Players Rigidbody for Movement
        playerBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // Check if the player is ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    // Handles the Movement
    void Movement()
    {
        // Horizontal Movement
        float Horizontal = 0;
        if (Input.GetKey(KeyCode.A))
        {
            Horizontal += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Horizontal += 1;
        }

        // Vertical Movement
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }

        // ADD FRICTION TO HORIZONTAL MOVEMENT

        playerBody.velocity = new Vector2(Horizontal * moveSpeed, playerBody.velocity.y);
    }

    // Very Basic Jump Function
    // Jumps if the player is grounded
    void Jump()
    {
        if (isGrounded)
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
        }
    }
}
