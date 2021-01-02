using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdFall : MonoBehaviour
{
    private Animator anim;
    public GameObject canvas;
    private AudioSource source;

    private AudioClip bird;
    private Rigidbody2D rb;



    void Start()
    {
        source = GetComponent<AudioSource>();
        canvas.SetActive(false);
        anim = GetComponent<Animator>();
       

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
            anim.SetTrigger("Fall");
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
