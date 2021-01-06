using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce;
    public float speed;
    
    private Animator anim;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;
    public float distance;
    public LayerMask whatIsLadder;
    public bool isClimbing;
    public float climbSpeed;
    private float inputVertical;
    public float health;
    public GameObject deathEffect;
    public GameObject deathSplatter;
    public GameObject blood;

    public GameObject bomb;

 
    public static Rigidbody2D rb;
    [SerializeField]
    private void Start()
    {

        
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);
        if (Input.GetKeyUp(KeyCode.C))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Z))
        {

            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isGrounded == true)
        {
            doubleJump = false;
            anim.SetBool("isJumping", false);
        }
        else
        {

            anim.SetBool("isJumping", true);
        }

        if (Input.GetKey(KeyCode.Z) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

               if (Input.GetKeyUp(KeyCode.Z))
        {
            isJumping = false;

        }

        if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.Z)) {
            isJumping = true;
            doubleJump = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

    }
   void FixedUpdate()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
        
        if(hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
               
            }
        } else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;
                anim.SetBool("isClimbing", false);
            }
            
        }
        if (isClimbing == true && hitInfo.collider != null)
        {

            inputVertical = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * climbSpeed);
            anim.SetBool("isClimbing", true);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 5;
            anim.SetBool("isClimbing", false);
        }
       

    }
    public void TakeDamage(int damage)
    {
       
        health -= damage;
       
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(deathSplatter, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }

}
