using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraDash : MonoBehaviour
{

    public Movement player;
    // Start is called before the first frame update
    void Start()
    {
       
        player = FindObjectOfType<Movement> ();
        GetComponent<Movement>().exDash();
    }

    // Update is called once per frame
    void Update()
    {

      
    }
}
