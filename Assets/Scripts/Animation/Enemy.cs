using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 1;
    public GameObject enemy;
    int currentHealth;
    Renderer enemyRendered;
    // Start is called before the first frame update
    void Start()
    {
        enemyRendered = GetComponent<Renderer>();
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth<= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        Destroy(enemy, 2);
    }

}
