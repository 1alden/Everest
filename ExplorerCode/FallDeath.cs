using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour 
{
    
    public int fallDamage;


  public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag(("Environment")))
        {
            Debug.Log(PlayerControllerGamesJames.rb.velocity.y);
            if (PlayerControllerGamesJames.rb.velocity.y < -25)
            {
                col.GetComponent<PlayerControllerGamesJames>().TakeDamage(fallDamage);
            }
        }

    }

}
