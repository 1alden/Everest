using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : MonoBehaviour
{
    public GameObject strawberryDust;
    public bool isCollected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(strawberryDust, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            isCollected = true;
        }

    }
}
