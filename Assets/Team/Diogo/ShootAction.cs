using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Shoot", story: "[Agent] [Attacks] [Target]", category: "Action", id: "b4560e1ca46336e214899b73fd4c1c8a")]
public partial class ShootAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<FireGun> Attacks;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float shootForce = 20f;
    public float cooldown = 1.5f;

    private float lastShotTime;

    protected override Status OnUpdate()
    {
        if (Target == null || Target.Value == null || firePoint == null)
            return Status.Failure;

        // Cooldown check
        if (Time.time - lastShotTime < cooldown)
            return Status.Running;

        // Look at player (optional, or use LookAt node)
        Vector3 direction = (Player.Value.transform.position - firePoint.position).normalized;

        // Instantiate projectile
        GameObject projectile = GameObject.Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        // Apply force
        if (projectile.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.linearVelocity = direction * shootForce;
        }

        lastShotTime = Time.time;
        return Status.Success;
    }
}

