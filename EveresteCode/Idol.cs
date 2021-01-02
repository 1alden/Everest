using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idol : MonoBehaviour
{
    private Animator anim;
    public GameObject oldClouds;
    public GameObject newClouds;
    public GameObject top1;
    public GameObject top2;
    public GameObject orb;
 
    public bool isCreated;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            anim.SetTrigger("Change");
            
            Destroy(oldClouds);
            Destroy(top1);
            Destroy(top2);
            
            if (!isCreated)
            {
                
                Instantiate(newClouds, transform.position, Quaternion.identity);
                Instantiate(orb, transform.position, Quaternion.identity);
                isCreated = true;
            }
        }
    }
}
