using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adddash : MonoBehaviour
{
    private Movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {


            Invoke("BalloonPop", 5);

            other.GetComponent<Movement>().normDash();
        }
   

    }
}
