using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatScript : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public int attackDamage = 1;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackRate = 0.2f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {

        if (Input.GetButtonDown("Attack"))
        {
            Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) 
        {
            Debug.Log("hit");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
