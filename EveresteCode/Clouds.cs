using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
   public float speed;
    public float minX;
    public float maxX;

    private void Start()
    {
      
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x > maxX) {
            Vector2 newPos = new Vector2(minX, transform.position.y);
            transform.position = newPos;
        }
    }
}
