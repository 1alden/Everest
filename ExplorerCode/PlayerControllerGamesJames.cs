using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGamesJames : MonoBehaviour 
{

   

    public float moveSpeed;
    public float crouchSpeed;
    public float jumpHeight;

    public static Rigidbody2D rb;
   
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public float hangTime = .2f; //Jump time after leaving platform
    private float hangCounter;

    public float jumpBufferLength = .1f; //Jump time before hitting platform
    private float jumpBufferCount;

    public Animator anim;

    public GameObject bomb;

    public GameObject splatter;
    public Transform splatterPoint;

    public int health;

    public float sprintSpeed;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask whatIsEnemy;
    public int damage;

    public bool onLadder;

    public float climbSpeed;
    private float climbVelocity;

    private float gravityStore;

    public LayerMask whatIsDestructible;
    public GameObject PlayerBlood;
    public GameObject DeathBlood;

    public int fallDamage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityStore = rb.gravityScale;
       

    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
   
    void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.C))
        {
            Instantiate(bomb, transform.position, Quaternion.identity);
        }


        //Move
        float moveInput = Input.GetAxisRaw("Horizontal");
        float vertInput = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Move

        if (moveInput != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); //Flip
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //Flip
        }


        //Jump
        if (grounded && onLadder == false)    // Hang Time
        {
            anim.SetBool("IsJumping", false);
            hangCounter = hangTime;
        } else
        {
            hangCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
           
            jumpBufferCount = jumpBufferLength;
        } else
        {
            jumpBufferCount -= Time.deltaTime;
        }

            if (jumpBufferCount >= 0 && hangCounter > 0)     
        {
            rb.velocity = new Vector2 (rb.velocity.x, jumpHeight);
            jumpBufferCount = 0;
        }

            if(Input.GetKeyUp(KeyCode.Z) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }

            if (grounded == false)
        {
            anim.SetBool("IsJumping", true);
        }


        //Crouch
        if (Input.GetKey(KeyCode.DownArrow) && moveInput == 0)
        {
                anim.SetBool("IsCrouching", true);
        }

        else
        {
            anim.SetBool("IsCrouching", false);
        }

      
        //Crouch Walk
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (moveInput != 0) {
                anim.SetBool("IsCrouchWalking", true);
                rb.velocity = new Vector2(moveInput * crouchSpeed, rb.velocity.y);
            }
        }
        else
        {
            anim.SetBool("IsCrouchWalking", false);
        }
        //Sprint
        if (Input.GetKey(KeyCode.LeftShift) && (moveInput != 0) )
        
            
            {
                anim.SetBool("IsSprinting", true);
                rb.velocity = new Vector2(moveInput * sprintSpeed, rb.velocity.y);
            } else
            {
                anim.SetBool("IsSprinting", false);
            }
        
        if (Input.GetKeyDown(KeyCode.X) && grounded == true)
        {
            anim.SetTrigger("Chop");
           

        }

        if (onLadder)
        {

            
            rb.gravityScale = 0f;
            
            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                {

                    rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
                }
            
        } else
    
        {
            rb.gravityScale = gravityStore;
         
        }
      
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }

    
    void Attack()
    {
        FindObjectOfType<CameraShake>().Shake();
        Instantiate(splatter, splatterPoint.position, Quaternion.identity);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsEnemy);
        foreach (Collider2D col in enemiesToDamage)
          

            {
            col.GetComponent<EnemyDamage>().TakeDamage(damage);
            }

    }
    public void TakeDamage(int damage)
    {
        FindObjectOfType<CameraShake>().Shake();
        health -= damage;
        print(health);
        if (health <= 0)
        {
            
            Destroy(gameObject);
            Instantiate(DeathBlood, splatterPoint.position, Quaternion.identity);
        }
        else
        {
            Instantiate(PlayerBlood, splatterPoint.position, Quaternion.identity);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(("Environment")) && rb.velocity.y < -35)
        {
           
                Debug.Log("FallDamage");
                TakeDamage(fallDamage);
            
        }

    }
}
