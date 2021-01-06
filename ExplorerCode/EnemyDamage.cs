using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public int health;

    public GameObject blood;
    public GameObject deathEffect;
    public GameObject splat;
    public GameObject corpse;

    public Transform attackPoint;
    public float attackRadius;
    public LayerMask whatIsPlayer;
   

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.tag == ("Player"))
        {
            Debug.Log("ATTACK");
            Kill();
        }

    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(corpse, transform.position, Quaternion.identity);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(splat, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
       
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
    void Kill()
    {
        Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsPlayer);
        foreach (Collider2D col in playerToDamage)


        {
            col.GetComponent<PlayerControllerGamesJames>().TakeDamage(damage);
        }
    }
}