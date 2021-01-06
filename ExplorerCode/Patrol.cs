using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : EnemyDamage
{ 

    public float speed;
    

    private bool movingRight = true;

   

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;


    public Transform groundCheck1;
  
    public bool grounded1;
    


    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        grounded1 = Physics2D.OverlapCircle(groundCheck1.position, groundCheckRadius, whatIsGround);
    }

   public void Update()
    {
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (grounded == true) //detects drop
            {

                if (movingRight == false)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = true;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = false;
                }
            }
        
        if (grounded1 == false) //Detects Wall
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

    
   

