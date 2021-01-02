using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDash : MonoBehaviour
{
    private Movement player;
    
    CompositeCollider2D m_ObjectCollider;



    void Start()
    {
        m_ObjectCollider = GetComponent<CompositeCollider2D>();
        player = FindObjectOfType<Movement>();
    }

    
    void Update()
    {
        if(player.Dream == true)
        {
            m_ObjectCollider.isTrigger = true;
        } else
        {
            m_ObjectCollider.isTrigger = false;
        }






    }

}
