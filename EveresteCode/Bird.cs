using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator anim;
    public GameObject canvas;
    private AudioSource source;

    public AudioClip bird;
    private Rigidbody2D rb;



    void Start()
    {
        source = GetComponent<AudioSource>();
        canvas.SetActive(false);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            source.clip = bird;
            source.Play();
            anim.SetTrigger("Peck");
            canvas.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            source.clip = bird;
            source.Play();
            anim.SetBool("Flying", true);
           

        }

    }
}
