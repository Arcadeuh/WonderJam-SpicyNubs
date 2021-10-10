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
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

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
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        //play sfx when attacking
        SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.Attack);
    }

    public void GetHit()
    {
        Debug.Log("hit");
        animator.SetTrigger("Stun");

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float lowestDistance = float.PositiveInfinity;
        GameObject enemySelected = null;
        foreach(GameObject enemy in enemies)
        {
            if(Mathf.Abs(enemy.transform.position.magnitude - transform.position.magnitude) < lowestDistance)
            {
                lowestDistance = enemy.transform.position.magnitude;
                enemySelected = enemy;
            }
        }
        if(enemySelected.transform.position.x > transform.position.x) 
        { rb.AddForce(new Vector2(-20.0f, 15.0f) * rb.mass, ForceMode2D.Impulse); }
        else { rb.AddForce(new Vector2(20.0f, 15.0f) * rb.mass, ForceMode2D.Impulse); }

        //play sound when get hit
        SfxManager.SfxInstance.Audio.PlayOneShot(SfxManager.SfxInstance.GetHit);
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
