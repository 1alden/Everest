using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkBalloon : MonoBehaviour
{
    private Movement player;

    public GameObject blockDust;

    public float waitTime;
   


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Instantiate(blockDust, transform.position, Quaternion.identity);
            Invoke("BalloonPop", 0f);
other.GetComponent<Movement>().exDash();
            

        }

    }
    void BalloonPop()
    {

        gameObject.SetActive(false);
        Invoke("Respawn", waitTime);


    }
    public void Respawn()
    {

        gameObject.SetActive(true);
        Instantiate(blockDust, transform.position, Quaternion.identity);

    }
    
}
