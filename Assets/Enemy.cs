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
        Destroy(gameObject);
    }
    
    
    [SerializeField] private Transform player;        // Assign the player transform
    [SerializeField] private float lookAtRange = 10f; // Max distance to trigger look-at
    [SerializeField] private Transform camera;
    public float rotationSpeed = 2f;
    void LookAtUsingXAxis(Transform target, float rotationSpeed)
    {
        Vector3 direction = target.position - transform.position;

        // Base look rotation (Z axis pointing at the target)
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // Rotate -90° around Y so X axis points at the target
        targetRotation *= Quaternion.Euler(-90, 0, 0);

        // Smoothly rotate from current rotation to target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
    private void Update()
    {
        if (player == null) return;

        
        float distance = Vector3.Distance(camera.position, player.position);

        if (distance <= lookAtRange)
        {
            LookAtUsingXAxis(player, rotationSpeed);
        }
        
    }
}
