using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text WINTEXT;
    public float walkSpeed = 5f;
    public float runSpeed = 40f;
    public float JumpStrength = 4f;
    public bool isGrounded = false;
    public GameManagerScript gm;
    public int maxJumps = 1;
    public int jumpCount = 0;
    float horizontalMove;
    float verticalMove;
    bool facingRight = true;



    public Rigidbody2D rb;
    //public Animator animator;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        verticalMove = Input.GetAxisRaw("Vertical");

        //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        //if (verticalMove > 0.01 && (isGrounded || jumpCount<maxJumps))
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    void FixedUpdate()
    {

        if (horizontalMove != 0f)
        {
            rb.AddForce(new Vector2 (horizontalMove * walkSpeed, 0f), ForceMode2D.Impulse);
            //rb.AddForce(new Vector2(horizontalMove*speed, 0f));
        }

        //Flip 
        //if facing left and moveming to the right Flip function flips Sprite to the right
        if (horizontalMove > 0 && !facingRight)
        {
            Flip();
        }
        //if facing right and moving to the left Flip function flips Sprite to the left
        if (horizontalMove < 0 && facingRight)
        {
            Flip();
        }

    }
    void Flip()
    {
        //Sprite scale(which happens to be defined as localScale) is set to currentScale
        Vector3 currentScale = transform.localScale;
        //if Flip is called then it changes what ever the Scale is to negative therefore fliping the Sprite horizontally
        currentScale.x *= -1;
        transform.localScale = currentScale;
        //flips bool to true if false and vice-versa
        facingRight = !facingRight;
    }

    private void Jump()
    {
        //rb.AddForce(new Vector2(0f, verticalMove * JumpStrength), ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, JumpStrength);

    }
    private void OnTriggerEnter2D(Collider2D collision)//Trigger and WIN THE GAME
    {
        if (collision.tag == "win")
        {
            WINTEXT.gameObject.SetActive(true);
            collision.gameObject.SetActive(false);
            gm.GameOverUI();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Ground"))
       {
            isGrounded = true;
            jumpCount = 0; 
       }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Ensure the player remains grounded while touching any ground objects
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            //animator.SetBool("IsJumping", true);
        }
    }
}
