using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingBlock : MonoBehaviour
{
    Rigidbody2D rb;
    AudioSource source;

    public float TimeToFall;

    public AudioClip crush;
    public GameObject CrusherDustfall;
    public GameObject CrusherDustHit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.name.Equals("Player"))
        {
            Instantiate(CrusherDustfall, transform.position, Quaternion.identity);
            Invoke("Fall", TimeToFall);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Instantiate(CrusherDustHit, transform.position, Quaternion.identity);
            source.clip = crush;
            source.Play();
        }
    }
    void Fall()
    {
        rb.isKinematic = false;
    }
}
