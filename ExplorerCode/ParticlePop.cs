using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePop : MonoBehaviour
{
    public GameObject effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(effect, transform.position, Quaternion.identity);

        }
    }
}
