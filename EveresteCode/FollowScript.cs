using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform target;
public float moveSpeed = 5;
    public float rotationSpeed = 0;
    public Transform myTransform;
 
 public void Awake()
    {
        myTransform = transform;
    }

    public void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    public void Update()
    {
        var dist = Vector3.Distance(target.position, myTransform.position);
        var lookDir = target.position - myTransform.position;
        lookDir.y = 0;
       
               

        if (dist > 0.5)
        {
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
