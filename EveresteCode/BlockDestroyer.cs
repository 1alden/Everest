using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroyer : MonoBehaviour
{
    private Movement player;
    public GameObject BreakBlock;
    AudioSource source;


    public AudioClip crush;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            if (player.isDashing == true)
            {
                Instantiate(BreakBlock, transform.position, Quaternion.identity);
                source.clip = crush;
                source.Play();
                gameObject.SetActive(false);
            }
        }

    }
}
