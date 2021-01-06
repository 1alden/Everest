using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol2 : MonoBehaviour
{

    public float speed;


    private bool movingRight = true;



    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    public void Update()
    {
        
        if (grounded == false)
        {

            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }

    }
}


