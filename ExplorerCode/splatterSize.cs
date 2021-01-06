using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatterSize : MonoBehaviour
{
    private SpriteRenderer rend;
    public Sprite[] blood;

    // Start is called before the first frame update
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        int rand = Random.Range(0, blood.Length);
        rend.sprite = blood[rand];
    }

    
}
