using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 25;
    public float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var target = collision.collider.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        // Optional: spawn impact VFX here
        Destroy(gameObject);
    }
        
        
}

