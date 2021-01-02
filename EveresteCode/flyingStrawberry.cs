using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyingStrawberry : MonoBehaviour
{
    public GameObject strawberryDust;
    private Movement player;
    public float moveSpeed;
    private Rigidbody2D rb;
    private LevelManager manager;
    public float startX;
    public float startY;
    public float X;
    public float Y;


    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Movement>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        Vector2 newPos = new Vector2(startX, startY);
      
    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (player.hasDashed == true)
        {
            StartCoroutine("RespawBerryCo");
        } 

        
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Instantiate(strawberryDust, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            
        }
    }
    public IEnumerator RespawBerryCo()
    {
        transform.position = transform.position + new Vector3(X * speed * Time.deltaTime, Y * speed * Time.deltaTime, 0);
        yield return new WaitForSeconds(0);
        if(manager.levelReloaded == true)
        {
            Vector2 newPos = new Vector2(startX, startY);
            transform.position = newPos;
           
        }
    }
}
