using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRight : MonoBehaviour
{
   public float speed;
    public float minX;
    public float maxX;

    private void Start()
    {
      
    }

    private void Update()
    {
        transform.Translate(Vector2.right * -speed * Time.deltaTime);

        if (transform.position.x < minX) {
            Vector2 newPos = new Vector2(maxX, transform.position.y);
            transform.position = newPos;
        }
    }
}
