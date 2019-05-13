using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingComponent : MonoBehaviour
{
    public event Action onDeath = () => { };
    public event Action onDamage = () => { };
    public event Action onReplenish = () => { };

    [SerializeField] private GameObject _drop = null;

    [SerializeField] private int currentHealth = 3;
    [SerializeField] private int maxHealth = 3;

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
        onDamage.Invoke();

        currentHealth = currentHealth - value;

        if(currentHealth < 0)
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