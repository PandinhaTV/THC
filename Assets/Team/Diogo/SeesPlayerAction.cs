using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SeesPlayer", story: "If [self] sees [player] If [SeesPlayerCheck] is true", category: "Action", id: "6a7608206d06a0297c26e356c0d796ba")]
public partial class SeesPlayerAction : Action
{
    [SerializeReference] private BehaviorGraphAgent agent;
    [SerializeReference] public BlackboardVariable<GameObject> Self;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    
    
    public Transform eyesTransform;
   
    public float viewDistance = 15f;
    public float fieldOfView = 110f;
    public LayerMask obstacleMask;
    
    protected override Status OnStart()
    {
        
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Player != null && Player.Value != null)
        {
            Transform playerTransform = Player.Value.transform;
            // You can now use playerTransform.position, etc.
        }
        else
        {
            Debug.LogWarning("Player blackboard variable is not assigned or has no value.");
        }
        if (Player != null)
        {
            Vector3 direction = Player.Value.transform.position - eyesTransform.position;
            float distance = direction.magnitude;

            if (distance <= viewDistance)
            {
                float angle = Vector3.Angle(eyesTransform.forward, direction);

                if (angle <= fieldOfView * 0.5f)
                {
                    if (Physics.Raycast(eyesTransform.position, direction.normalized, out RaycastHit hit, viewDistance, ~obstacleMask))
                    {
                        if (hit.transform.CompareTag("Player"))
                        {
                            agent.SetVariableValue("SeesPlayerCheck", "true");
                            
                            return Status.Failure;
                        }
                            
                    }
                    
                }
            }
        }
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

