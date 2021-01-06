using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float timer;
    public int damage;
    public LayerMask whatIsDestructible;
    public float areaOfEffect;

    public GameObject effect;

    
    public Animator anim;

    

    public void Update()
    {
       
            if (timer <= 0)
        {
           
            Collider2D[] objectsToDamage = Physics2D.OverlapCircleAll(transform.position, areaOfEffect, whatIsDestructible);

            for (int i = 0; i < objectsToDamage.Length; i++)

            {
                objectsToDamage[i].GetComponent<TileDestroyer>().health -= damage;
                Instantiate(effect, transform.position, Quaternion.identity);
                anim.SetTrigger("Explode");
                FindObjectOfType<CameraShake>().Shake();
                Destroy(gameObject);
                
            }
            
           
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaOfEffect);
    }
}

