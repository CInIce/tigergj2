using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingComponent : MonoBehaviour
{
    public event Action onDeath = () => { };
    public event Action onDamage = () => { };
    public event Action onReplenish = () => { };

    [SerializeField] private int currentHealth = 3;
    [SerializeField] private int maxHealth = 3;

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }

    public void ReplenishHealth(int value)
    {
        onReplenish.Invoke();

        currentHealth += value;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void Damage(int value)
    {
        currentHealth = currentHealth - value;

        onDamage.Invoke();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        onDeath.Invoke();

        Destroy(gameObject);
    }
}