using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{

    private Animator anim;
    private Movement move;
    private Collision coll;
    [HideInInspector]
    public SpriteRenderer sr;
   

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponentInParent<Collision>();
        move = GetComponentInParent<Movement>();
        sr = GetComponent<SpriteRenderer>();
     
    }

    void Update()
    {
        anim.SetBool("onGround", coll.onGround);
        anim.SetBool("onWall", coll.onWall);
        anim.SetBool("onRightWall", coll.onRightWall);
        anim.SetBool("wallGrab", move.wallGrab);
        anim.SetBool("wallSlide", move.wallSlide);
        anim.SetBool("canMove", move.canMove);
        anim.SetBool("isDashing", move.isDashing);
        anim.SetBool("isTired", move.tired);
        anim.SetBool("lookingUp", move.isLookingUp);
        anim.SetBool("lookingDown", move.isLookingDown);
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("lookingDown", true);

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("lookingUp", true);
        }
        if (move.wallGrabTime <= 0.5 && coll.onWall)
        {
            anim.SetBool("wallGrab", false);
            anim.SetBool("isTired", true);
           
        }
        else
        {
            anim.SetBool("isTired", false);
        }

    }

    public void SetHorizontalMovement(float x,float y, float yVel)
    {
        anim.SetFloat("HorizontalAxis", x);
        anim.SetFloat("VerticalAxis", y);
        anim.SetFloat("VerticalVelocity", yVel);

    }

    public void SetTrigger(string trigger)
    {
        anim.SetTrigger(trigger);

    }

    public void Flip(int side)
    {

        if (move.wallGrab || move.wallSlide)
        {
            if (side == -1 && sr.flipX)
                return;

            if (side == 1 && !sr.flipX)
            {
                return;
            }
        }

        bool state = (side == 1) ? false : true;
        sr.flipX = state;
    }
   
}
