using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orb : Movement
{
    
    private Movement player;
    AudioSource source;
    public GameObject orbed;

    public AudioClip orber;

    // Start is called before the first frame update
    void Start()
    {
        orbed.SetActive(true);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            orbed.SetActive(false);
            numberOfNewDashes = 1;
        }
    }
}
