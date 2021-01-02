using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   private Chest chest;
    // Start is called before the first frame update
    void Start()
    {
        chest = FindObjectOfType<Chest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            
            {
                chest.Opening();
            }
        }
    }

}
