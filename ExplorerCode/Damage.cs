using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D(Collider collision)
    {
        
            if (collision.tag == "Player")
            {
            HealthTextScript.health -= damage;
            
            }
        
    }
   
}
