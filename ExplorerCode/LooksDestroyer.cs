using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LooksDestroyer : MonoBehaviour
{
   





        void OnTriggerEnter2D(Collider2D other)
        {

            {


                if (other.gameObject.tag == "Environment")
                {
                    Destroy(gameObject);
                    
                }

            }
        }
    
}
