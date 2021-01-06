using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour
{
    private PlayerControllerGamesJames player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControllerGamesJames>()
;    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.tag == "Player")
        {

            player.onLadder = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.onLadder = false;
        }
    }
}
