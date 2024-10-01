using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int maxJumps = 2;
    public int jumpCount;
    private bool isGrounded;
    public float RotateSpeed = 5f;
    public float JumpStrength = 10f;
    public float speed = 5f; // Speed of the rolling
    public float rotationSpeed = 200f; // Speed of the rotation
    // Start is called before the first frame update
    void Start()
    {
        jumpCount = 0;
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        //Jumps should reset if you have jumped atleast once and are touching the floor
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }
         //Horizontal Movement for Sprites
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(moveInput * speed, rb.velocity.y); // Calculate movement vector

        rb.velocity = move; // Apply movement

    }
    void Jump()
    {
        rb.velocity = Vector2.up * JumpStrength;
        jumpCount++;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
  