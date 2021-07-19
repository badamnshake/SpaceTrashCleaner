using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    public float maxHealth;
    float currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void Restore(float percentageFraction)
    {
        return;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

}
