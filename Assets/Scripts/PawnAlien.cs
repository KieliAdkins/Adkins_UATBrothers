using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAlien : Pawn {

    // Declaring our variables
    private Transform tf; 
    private Rigidbody2D rb;
    private Animator an;
    private SpriteRenderer sr;

    // Player information
    public float moveSpeed;
    public int jumpForce;

    // Finding if the player is on the ground
    public bool isGrounded;
    public float groundedDistance; 

	// Use this for initialization
	void Start () {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>(); 
	}
	
	// Update is called once per frame
	void Update () {

        // Checking for grounded while character is falling
        if (rb.velocity.y <= 0.1f)
        {
            // Calling the check for ground function
            CheckForGrounded();
        }
	}

    // Move function
    public override void Move (float direction)
    {
        // Character movement
        tf.position += Vector3.right * direction * moveSpeed;

        // Playing the walk animation
        an.Play("Walk"); 

        if (direction < 0)
        {
            sr.flipX = true; 
        }

        else
        {
            sr.flipX = false;
        }
    }

    // Checking if the pawn is on the ground
    public void CheckForGrounded()
    {
        // Variable to hold our about raycast hit
        RaycastHit2D hitInfo;

        // Casting our raycast
        hitInfo = Physics2D.Raycast(tf.position, Vector2.down, groundedDistance);

        Debug.DrawLine(tf.position, tf.position + (Vector3.down * groundedDistance));

        // Checking if we hit "ground"
        if (hitInfo.collider != null)
        {
            // if it is set our variable
            if (hitInfo.collider.gameObject.tag == "Ground")
            {
                isGrounded = true; 
            }

            // else set variable false
            else
            {
                isGrounded = false; 
            }
        }

        // If nothing is hit
        else
        {
            isGrounded = false; 
        }
    }

    // Jump function
    public override void Jump()
    {
        // If we are on the ground allow player to jump
        if (isGrounded)
        {
            // Adding the jump force
            rb.AddForce(Vector2.up * jumpForce);

            // Beginning the jump animations
            an.Play("Jump");
        }
    }
}
