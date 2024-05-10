using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    public HealthbarBehavior healthbar;
    public Slider slider;
    public GameObject deathEffect;
    public int enemyAttackDamage = 10;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth, maxHealth);
    }

    // Take damge from the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth, maxHealth);

        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        //StartCoroutine(EnemyDie());
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        animator.SetBool("isDead", true);
        Destroy(gameObject);
    }
    IEnumerator EnemyDie()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    } 
}
