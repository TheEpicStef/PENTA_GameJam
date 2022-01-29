using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerBody;

    public SpriteRenderer playerSprite;

    [Header("Movement")]
    // The Base Movement Speed
    public float speed = 0.0f;
    // The Max Speed you can achieve
    public float maxSpeed = 4.0f;
    // The Acceleration Speed
    public float accelSpeed = 5.0f;
    // The Decceleration Speed
    public float deccelSpeed = 10.0f;
    // Friction Multiplier
    public float frictionMultiplier = 1.0f;

    // The Height to jump
    public float jumpSpeed = 5.0f;

    [Header("Ground Check")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Set to stop jumping when in water.
    public bool inWater = false;

    void Start()
    {
        // Get the Players Rigidbody for Movement
        playerBody = this.GetComponent<Rigidbody2D>();

        playerSprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        // Check if the player is ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        inWater = false;
    }

    // Flips the Sprite based on direction of momentum.
    void DirectionUpdate()
    {
        playerSprite.flipX = speed < 0;
    }

    // Handles the Movement
    void Movement()
    {
        // Handle Left and Right input with acceleration
        // Setup to just stop if both keys are pressed
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            speed = speed - (accelSpeed * Time.deltaTime);
            DirectionUpdate();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            speed = speed + (accelSpeed * Time.deltaTime);
            DirectionUpdate();
        }
        // Deceleration system
        // Will decelerate towards 0. Friction Multiplier can be changed to swap how effective friction is.
        else
        {
            // Handle Deceleration
            if (speed > (deccelSpeed * Time.deltaTime))
            {
                speed = speed - (deccelSpeed * frictionMultiplier * Time.deltaTime);
            }
            else if (speed < (-deccelSpeed * Time.deltaTime))
            {
                speed = speed + (deccelSpeed * frictionMultiplier * Time.deltaTime);
            }
            else
            {
                speed = 0;
            }
        }

        // Clamp the movement between the max values
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        // Vertical Movement
        if (Input.GetKey(KeyCode.W))
        {
            Jump();
        }

        playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
    }

    // Very Basic Jump Function
    // Jumps if the player is grounded and not in water
    void Jump()
    {
        if (isGrounded && !inWater)
        {
            playerBody.velocity = Vector2.up * jumpSpeed;
        }
    }
}
