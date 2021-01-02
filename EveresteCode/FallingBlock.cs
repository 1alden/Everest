using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    public GameObject blockDust;
    public float timeToFall;
    public float timeToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(blockDust, transform.position, Quaternion.identity);
            Invoke("DropPlatform", timeToFall);
            anim.SetTrigger("Break");
           
        }
        
    }
    void DropPlatform()
    {
        gameObject.SetActive(false);
        Invoke("Respawn", timeToSpawn);
        
    }
    public void Respawn()
    {
        anim.SetTrigger("Restore");
        gameObject.SetActive(true);
        
    }
}
