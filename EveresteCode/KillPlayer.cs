using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public float waitTime;
    private float waitCounter;
    private Movement player;
    public LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "Player")
        {

            player.hasDashed = true;
            levelManager.RespawnPlayer();
            
        }
    }

}
