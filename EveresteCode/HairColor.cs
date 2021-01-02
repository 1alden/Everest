using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairColor : MonoBehaviour
{
    private Movement player;
    private Renderer rend;
    private LevelManager manager;

    [SerializeField]
    private Color colorToTurnTo = Color.white;
    [SerializeField]
    private Color startingColor = Color.white;
    [SerializeField]
    private Color pinkHair = Color.white;

    void Start()
    {
        player = FindObjectOfType<Movement>();
        rend = GetComponent<Renderer>();
        rend.material.color = startingColor;
        manager  = FindObjectOfType<LevelManager>();
    }

    
    void Update()
    {
        if (player.numberOfDashes <= -1)
        {
            rend.material.color = colorToTurnTo;
        }
        if(player.numberOfDashes == 0)
        {
            rend.material.color = startingColor;
        }
        if (player.numberOfDashes >= 1)
        {
            rend.material.color = pinkHair;
        }
        if (manager.levelReloading == true)
        {
            rend.enabled = false;
        } else
        {
            rend.enabled = true;
        }
    }
}
