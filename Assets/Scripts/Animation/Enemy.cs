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

    private EnemySpawner EnemySpawning;     //value to have enemy spawn at pt

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

        //play sound when get hit
        SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.GetHit);
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<Rigidbody2D>().simulated = false;
        Destroy(enemy, 2);

        EnemySpawning = FindObjectOfType<EnemySpawner>();       //keep track of amount of enemies in level
        EnemySpawning.enemiesInLevel--;

        if (EnemySpawning.spawnTime<0 && EnemySpawning.enemiesInLevel <= 0)
        {
            EnemySpawning.spawnerDone = true;
        }
    }

}
