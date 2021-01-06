using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject player;
   
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);

    }

    private void Update()
    {
        
    }
}
