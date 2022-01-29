using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerBody;

    public SpriteRenderer playerSprite;

    public Animator playerAnimator;

    [Header("Movement")]
    // The Base Movement Speed
    public float speed = 0.0f;
    // The Max Speed you can achieve
    public float maxSpeed = 3.0f;
    // The Acceleration Speed
    public float accelSpeed = 5.0f;
    // The Decceleration Speed
    public float deccelSpeed = 10.0f;

    [Header("Friction Settings")]
    // Deccelleration Speed Multiplier
    public float deccelMultiplier = 1.0f;
    // 
    public float accelMultiplier = 1.0f;

    // The Height to jump
    public float jumpSpeed = 5.0f;

    [Header("Ground Check")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float jumpDelay = 1.0f;
    public float jumpTimer = 0.0f;
    public bool hasJumped = false;

    // Set to stop jumping when in water.
    public bool inWater = false;

    public bool isFrozen = false;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip jumpAudio;
    public AudioClip jumpAudio2;
    public AudioClip landAudio;

    public AudioClip[] footstepAudio;

    public AudioClip freezeAudio;
    public AudioClip unfreezeAudio;



    void Start()
    {
        // Get the Players Rigidbody for Movement
        playerBody = this.GetComponent<Rigidbody2D>();

        playerSprite = this.GetComponent<SpriteRenderer>();

        playerAnimator = this.GetComponent<Animator>();

        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        FrictionChange();
        Movement();
        AnimationHandler();

        // Check if the player is ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        playerAnimator.SetBool("Grounded", isGrounded);

        jumpTimer += Time.deltaTime;
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
        if (playerBody.bodyType == RigidbodyType2D.Static) return;

        // Handle Left and Right input with acceleration
        // Setup to just stop if both keys are pressed
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            speed = speed - (accelSpeed * accelMultiplier * Time.deltaTime);
            DirectionUpdate();
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            speed = speed + (accelSpeed * accelMultiplier * Time.deltaTime);
            DirectionUpdate();
        }
        // Deceleration system
        // Will decelerate towards 0. Friction Multiplier can be changed to swap how effective friction is.
        else
        {
            // Handle Deceleration
            if (speed > (deccelSpeed * Time.deltaTime))
            {
                speed = speed - (deccelSpeed * deccelMultiplier * Time.deltaTime);
            }
            else if (speed < (-deccelSpeed * Time.deltaTime))
            {
                speed = speed + (deccelSpeed * deccelMultiplier * Time.deltaTime);
            }
            else
            {
                speed = 0;
            }
        }

        // Clamp the movement between the max values
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        // Vertical Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        playerBody.velocity = new Vector2(speed, playerBody.velocity.y);
    }

    // Very Basic Jump Function
    // Jumps if the player is grounded and not in water
    void Jump()
    {
        if (isGrounded)
        {
            playerBody.velocity = Vector2.up * (jumpSpeed * accelMultiplier);
            playerAnimator.SetTrigger("Jump");

            hasJumped = !(jumpTimer > jumpDelay);

            if (!hasJumped)
            {
                audioSource.PlayOneShot(jumpAudio);
                hasJumped = true;
                jumpTimer = 0.0f;
            }
            else
            {
                jumpTimer = 0.0f;
                audioSource.PlayOneShot(jumpAudio2, 1.5f);
            }
        }
    }
    
    void AnimationHandler()
    {
        if (playerBody.bodyType == RigidbodyType2D.Static)
        {
            playerAnimator.speed = 0;
            return;
        }
        playerAnimator.SetFloat("Vertical Speed", playerBody.velocity.y);
        playerAnimator.speed = 1;
        playerAnimator.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));
    }

    // Checks the ground type for friction changes
    void FrictionChange()
    {
        Collider2D groundCollision = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        // Handles the Water acceleration multiplier
        if (inWater)
        {
            accelMultiplier = 0.9f;
        }
        else
        {
            accelMultiplier = 1.0f;
        }


        if (!isGrounded)
        {
            deccelMultiplier = 0.5f;
        }
        else if (groundCollision != null)
        {
            if (groundCollision.tag == "Ice")
            {
                deccelMultiplier = 0.2f;
                maxSpeed = 6.0f;
            }
            else
            {
                deccelMultiplier = 1.0f;
                maxSpeed = 3.0f;
            }
        }
    }

    public void playSoundLand()
    {
        audioSource.PlayOneShot(landAudio, 10f);
    }


    public void playRandomFootstepSound()
    {
        audioSource.PlayOneShot(footstepAudio[Random.Range(0, footstepAudio.Length - 1)], 2f);
    }

    public void Freeze()
    {
        if (!isFrozen)
        {
            audioSource.PlayOneShot(freezeAudio, 3f);
            isFrozen = true;
        }
    }

    public void UnFreeze()
    {
        if (isFrozen)
        {
            audioSource.PlayOneShot(unfreezeAudio, 3f);
            isFrozen = false;
        }
    }
}
