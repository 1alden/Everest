using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    public GameObject deathEffect;
    public GameObject respawnEffect;

    private Movement player;
    private AnimationScript anim;
    public float respawnDelay = 0.1f;
    public bool levelReloaded;
    public float timeToSpawn = .5f;
    public bool levelReloading;
    public GameObject gameCanvas;
    AudioSource source;
    private hairV2 hair;
    public GameObject person;

    public AudioClip deathSound;
    public AudioClip respawn;
    void Start()
    {
        player = FindObjectOfType<Movement>();
        anim = FindObjectOfType<AnimationScript>();
        gameCanvas.SetActive(true);
        source = GetComponent<AudioSource>();
        hair = FindObjectOfType<hairV2>();
        Invoke("UI", 1f);
    }

    
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        
        StartCoroutine("RespawPlayerCo");
    }


    public IEnumerator RespawPlayerCo()
    {
        player.hasDashed = true;
        source.clip = deathSound;
        source.Play();
        levelReloading = true;
        Debug.Log("Reloading");
        player.canMove = false;

        person.SetActive(false);
        Instantiate(deathEffect, player.transform.position, player.transform.rotation);
       
       
        gameCanvas.SetActive(true);
        hair.transform.position = currentCheckpoint.transform.position;
        player.hasDashed = true;
        player.transform.position = currentCheckpoint.transform.position;

        yield return new WaitForSeconds(respawnDelay);

        anim.gameObject.transform.localScale = new Vector3(1, 1, 1);
        person.SetActive(true);
        Instantiate(respawnEffect, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        Invoke("Move", timeToSpawn);
        Debug.Log("Reloaded");
        player.hasDashed = true;
        levelReloading = false;
        source.clip = respawn;
        source.Play();



    }
    public void Move()
    {
        gameCanvas.SetActive(false);
        player.canMove = true;
    }
    public void UI()
    {
        gameCanvas.SetActive(false);
 
    }



}
