using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow) && moveInput > 0)
            {
                direction = 1;
            } else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow) && moveInput < 0)
                {
                direction = 2;
            } 
        }
        else
        {

            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
            }
            else
            {
                dashTime -= Time.deltaTime;


                if (direction == 1)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                if (direction == 2)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                
            }
        }
    }
}
