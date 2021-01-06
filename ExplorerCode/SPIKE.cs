using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPIKE : MonoBehaviour
{
    public PlayerControllerGamesJames player;
    public int damage;
    public void Start()
    {
        player = FindObjectOfType<PlayerControllerGamesJames>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && PlayerControllerGamesJames.rb.velocity.y < -5)
        {

            other.GetComponent<PlayerControllerGamesJames>().TakeDamage(damage);
        }
    }
}
