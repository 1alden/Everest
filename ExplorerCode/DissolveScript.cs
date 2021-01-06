using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{
    Material material;

    bool isDissolving;
    float fade = 1f;
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDissolving = true;
        }
        if (isDissolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
            }
            material.SetFloat("_Fade", fade);
        }
        
    }
}
