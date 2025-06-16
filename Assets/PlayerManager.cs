using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public void Update()
    {
        //
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }
    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }
    private void Die()
    {
        // Play de"ath animation, disable AI, ragdoll, etc.
        Debug.Log("Player Death");
    }
}
