using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelStarter : MonoBehaviour
{
    private bool isCreated;
    public GameObject StartGame;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
           
            if (!isCreated)
            {

                
                Instantiate(StartGame, transform.position, Quaternion.identity);
                isCreated = true;
            }
        }
    }
}
