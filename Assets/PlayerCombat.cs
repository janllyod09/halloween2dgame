using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackdamage = 20;
    public float attackRate = 2f;
    [SerializeField] private AudioSource swordSoundEffect;

    void Start()
    {
        
    }
    void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                swordSoundEffect.Play();
                Attack();
            }
        }
    }

    //  Attack the enemy
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackdamage);
        }
    }

    // Show the  range of attack
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange); 
    }

}
