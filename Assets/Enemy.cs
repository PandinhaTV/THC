using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int amount);
}
public class Enemy : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    } 

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        // Play death animation, disable AI, ragdoll, etc.
        Destroy(gameObject, 2f);
    }
}
