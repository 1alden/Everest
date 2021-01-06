using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
   
    public int health;

    public TMP_Text text;

    public int startingHealth;

    public PlayerControllerGamesJames player;



    void Start()
    {
        text = GetComponent<TMP_Text>();

        health = startingHealth;
        player = FindObjectOfType<PlayerControllerGamesJames>();



    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + health;
    }

}
