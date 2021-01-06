using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    public static Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Environment")
        {
            GetComponent<PlayerControllerGamesJames>().grounded = true;
            rb.velocity = Vector2.zero;
        }
    }
}
