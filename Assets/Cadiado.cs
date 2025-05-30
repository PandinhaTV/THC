using UnityEngine;
using UnityEngine.Events;

public class Cadiado : MonoBehaviour, IDamageable
{
    [SerializeField] private UnityEvent onCodeCorrect;
    public int maxHealth = 100;
    private int currentHealth;
    public Rigidbody door;
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
        //door.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
        onCodeCorrect.Invoke();
        Destroy(gameObject);
    }
}
