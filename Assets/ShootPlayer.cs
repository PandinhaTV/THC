using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 10f;
    public float cooldown = 1.5f;

    private float lastShotTime;

    public GameObject Player; // You can assign this manually or via script

    
    public void Shoot()
    {
        if (Player == null || firePoint == null)
        {
            Debug.LogWarning("Missing Player reference or FirePoint");
            return;
        }

        if (Time.time - lastShotTime < cooldown)
        {
            // Still on cooldown
            return;
        }

        // Get direction to player
        Vector3 direction = (Player.transform.position - firePoint.position).normalized;

        // Instantiate projectile
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        // Apply force if it has a Rigidbody
        if (projectile.TryGetComponent<Rigidbody>(out var rb))
        {
            Debug.Log("Shoot");
            rb.linearVelocity = direction * shootForce;
        }

        lastShotTime = Time.time;
    }
}