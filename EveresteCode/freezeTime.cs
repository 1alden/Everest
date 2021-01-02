using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeTime : MonoBehaviour
{
    private Movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
        ResumeGame();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player.isDashing)
        {
            ResumeGame();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        PauseGame();
    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
