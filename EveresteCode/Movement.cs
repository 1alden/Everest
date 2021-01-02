using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// ///////////////////////
/// </summary>
public class Movement : MonoBehaviour
{
    private Collision coll;
    [HideInInspector]
    public Rigidbody2D rb;
    private AnimationScript anim;
    public LevelManager level;
    

    [Space]
    [Header("Stats")]
    public float speed = 10;
    public float jumpForce = 50;
    public float slideSpeed = 5;
    public float wallJumpLerp = 10;
    public float dashSpeed = 20;
    public float gravity;
    public float trampoine;
    public float wallJumpForceX;
    public float wallJumpForceY;
    public float wallGrabTime;
    public int numberOfDashes;
    public static int numberOfNewDashes;
   

    [Space]
    [Header("Booleans")]
    public bool canMove;
    public bool wallGrab;
    public bool wallJumped;
    public bool wallSlide;
    public bool isDashing;
    public bool tired;
    public bool isLookingUp;
    public bool isLookingDown;

    [Space]

    public bool groundTouch;
    public bool hasDashed;
    public int side = 1;

    [Space]
    [Header("Polish")]
    public ParticleSystem dashParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem wallJumpParticle;
    public ParticleSystem slideParticle;

    AudioSource source;
   

    public AudioClip jumpSound;
    public AudioClip dashSound;
    public AudioClip dashNullSound;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;


    public float hangTime = .2f; // time After jumping
    private float hangCounter = .1f;

    public float jumpBufferLength; // time Before hitting the ground
    private float jumpBufferCount;
    public bool Dream;

    private LevelManager manager;

    //Dream Dash
    private float dashTime;
    public float startDashTime;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collision>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<AnimationScript>();
        level = GetComponentInChildren<LevelManager>();
        source = GetComponent<AudioSource>();
        dashTime = startDashTime;
        manager = FindObjectOfType<LevelManager>();

        
       
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);



        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);
        anim.SetHorizontalMovement(xRaw, yRaw, rb.velocity.y);

        if (coll.onWall && Input.GetKey(KeyCode.C) && canMove)
        {
            if(side != coll.wallSide)
            anim.Flip(side * -1);
            wallGrab = true;
            wallSlide = false;
        }

        if (Input.GetKeyUp(KeyCode.C) || !coll.onWall || !canMove)
        {
            wallGrab = false;
            wallSlide = false;
        }

        if (coll.onGround && !isDashing)
        {
            wallJumped = false;
           
           
        }
        if (Input.GetKeyDown(KeyCode.X) && hasDashed == true)
        {
            source.clip = dashNullSound;
            source.Play();
        }

        if (wallGrab && !isDashing)
        {
            if (wallGrabTime >= 0)
            {
                rb.gravityScale = 0;
                if (x > .2f || x < -.2f)
                    rb.velocity = new Vector2(rb.velocity.x, 0);

                float speedModifier = y > 0 ? .5f : 1;

                rb.velocity = new Vector2(rb.velocity.x, y * (speed * speedModifier));
                wallGrabTime -= Time.deltaTime;
            } else
            {
                rb.gravityScale = gravity;
                wallGrab = false;
            }
        }
        else
        {
            rb.gravityScale = gravity;
        }

        if(coll.onWall && !coll.onGround)
        {
            if (x != 0 && !wallGrab && y <= 0)
            {
                wallSlide = true;
                WallSlide();
            }
        }
        if (!coll.onWall || coll.onGround)
            wallSlide = false;




        if (grounded)
        {
            hangCounter = hangTime;
        } else
        {
            hangCounter -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jumpBufferCount = jumpBufferLength;
        }
        else
        {
            jumpBufferCount -= Time.deltaTime;
        }



        //JUMP
        if (Input.GetKeyDown(KeyCode.Z) && coll.onWall && !grounded)
        {
                WallJump();
        }

        if (jumpBufferCount >= 0 && hangCounter > 0f)
        {
            Jump(Vector2.up, false);
            anim.SetTrigger("jump");
            jumpBufferCount = 0;
        }

       






        //////// DASHING
        ///
        if (grounded)
            numberOfDashes = numberOfNewDashes;

        if (Input.GetKeyDown(KeyCode.X) && numberOfDashes >= 0)
        {
            if(xRaw != 0 || yRaw != 0)
                source.clip = dashSound;
            source.Play();
            Dash(xRaw, yRaw);
            
        }
        // Dream Dash
        if (Dream == true)
        {

            StartCoroutine("DreamDash");
        }





















            if (coll.onGround && !groundTouch)
        {
            GroundTouch();
            groundTouch = true;
        }

        if(!coll.onGround && groundTouch)
        {
            groundTouch = false;
        }

        WallParticle(y);

        if (wallGrab || wallSlide || !canMove)
            return;

        if(x > 0)
        {
            side = 1;
            anim.Flip(side);

        }
        if (x < 0)
        {
            side = -1;
            anim.Flip(side);
        }
        


    }

    void GroundTouch()
    {
        hasDashed = false;
        isDashing = false;
        wallGrabTime = 2f;

        side = anim.sr.flipX ? -1 : 1;

        jumpParticle.Play();
    }

    private void Dash(float xRaw, float yRaw)
    {
        Camera.main.transform.DOComplete();
        Camera.main.transform.DOShakePosition(.2f, .5f, 14, 90, false, true);
        FindObjectOfType<RippleEffect>().Emit(Camera.main.WorldToViewportPoint(transform.position));
        
        
            hasDashed = true;
        

        anim.SetTrigger("dash");

        rb.velocity = Vector2.zero;
        Vector2 dir = new Vector2(xRaw, yRaw);

        rb.velocity += dir.normalized * dashSpeed;
        numberOfDashes--;

        StartCoroutine(DashWait());
    }

    IEnumerator DashWait()
    {
        FindObjectOfType<GhostTrail>().ShowGhost();
        StartCoroutine(GroundDash());
        DOVirtual.Float(14, 0.1f, .7f, RigidbodyDrag);

        dashParticle.Play();
        rb.gravityScale = -0.1f;
        
        wallJumped = true;
        isDashing = true;

        yield return new WaitForSeconds(.1f);

        dashParticle.Stop();
        rb.gravityScale = gravity;
       
        wallJumped = false;
        isDashing = false;
    }

    IEnumerator GroundDash()
    {
        yield return new WaitForSeconds(.15f);
        if (coll.onGround)
            hasDashed = false;
    }

    private void WallJump()
    {
       
        
            if ((side == 1 && coll.onRightWall) || side == -1 && !coll.onRightWall)
            {
                side *= -1;
            anim.Flip(side);
            source.clip = jumpSound;
            source.Play();

        }

            StopCoroutine(DisableMovement(0));
            StartCoroutine(DisableMovement(.1f));

            Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

            Jump((Vector2.up / wallJumpForceY + wallDir / wallJumpForceX), true);

            wallJumped = true;
        

    }

    private void WallSlide()
    {
        if(coll.wallSide != side && rb.velocity.y <= 0)
            anim.Flip(side * -1);

        if (!canMove)
            return;

        bool pushingWall = false;
        if((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall ))
        {
            pushingWall = true;
        }
        float push = pushingWall ? 0 : rb.velocity.x;

        rb.velocity = new Vector2(push, -slideSpeed);
    }

    private void Walk(Vector2 dir)
    {
        if (!canMove)
            return;

        if (wallGrab)
            return;

        if (!wallJumped)
        {
            rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, (new Vector2(dir.x * speed, rb.velocity.y)), wallJumpLerp * Time.deltaTime);
        }
    }

    private void Jump(Vector2 dir, bool wall)
    {
        slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
        ParticleSystem particle = wall ? wallJumpParticle : jumpParticle;
        source.clip = jumpSound;
        source.Play();
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        particle.Play();
    }




    public IEnumerator DreamDash()
    {
        Invoke("DreamDashing", 0);
        
        yield return new WaitForSeconds(0);








    }
    IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    void RigidbodyDrag(float x)
    {
        rb.drag = x;
    }

    void WallParticle(float vertical)
    {
        var main = slideParticle.main;

        if (wallSlide || (wallGrab && vertical < 0))
        {
            slideParticle.transform.parent.localScale = new Vector3(ParticleSide(), 1, 1);
            main.startColor = Color.white;
        }
        else
        {
            main.startColor = Color.clear;
        }
    }

    int ParticleSide()
    {
        int particleSide = coll.onRightWall ? 1 : -1;
        return particleSide;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Trampoline"))
            rb.velocity = Vector2.up * 10 * trampoine;
        hasDashed = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        float xRaw = Input.GetAxisRaw("Horizontal");
        float yRaw = Input.GetAxisRaw("Vertical");
        if (col.gameObject.tag.Equals("Cloud") && rb.velocity.y <= 0)
        {
            this.transform.parent = col.transform;
        }

        if(col.gameObject.tag.Equals("Dream") && isDashing)
        {

            Dream = true;
           
        }
        else
        {
            Dream = false;
        }
        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Cloud"))

            this.transform.parent = null;

    }
   public void normDash()
    {
        numberOfDashes = 0;
        numberOfNewDashes = 0;
    }
    public void exDash()
    {
        numberOfDashes = 1;
        numberOfNewDashes = 1;
    }

   public void DreamDashing()
    {
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)))
            {
                direction = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && (!Input.GetKey(KeyCode.UpArrow)) && (!Input.GetKey(KeyCode.DownArrow)))
            {
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && (!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.LeftArrow)))
            {
                direction = 3;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && (!Input.GetKey(KeyCode.RightArrow)) && (!Input.GetKey(KeyCode.LeftArrow)))
            {
                direction = 4;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.UpArrow)))
            {
                direction = 5;
            }
            else if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.UpArrow)))
            {
                direction = 6;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.DownArrow)))
            {
                direction = 7;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.DownArrow)))
            {
                direction = 8;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                else if (direction == 3)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
                else if (direction == 4)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
                else if (direction == 5)
                {
                    rb.velocity = new Vector2(-dashSpeed, dashSpeed);
                }
                else if (direction == 6)
                {
                    rb.velocity = new Vector2(dashSpeed, dashSpeed);
                }
                else if (direction == 7)
                {
                    rb.velocity = new Vector2(-dashSpeed, -dashSpeed);
                }
                else if (direction == 8)
                {
                    rb.velocity = new Vector2(dashSpeed, -dashSpeed);
                }
            }
        }
    }

}
