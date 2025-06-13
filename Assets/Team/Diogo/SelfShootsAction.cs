using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Self Shoots", story: "[Agent] Shoots", category: "Action", id: "85c019a7999b8b10858f8ede4a9536f5")]
public partial class SelfShootsAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Agent == null || Agent.Value == null)
            return Status.Failure;
        var script = Agent.Value.GetComponent<ShootPlayer>();
        if (script != null)
        {
            script.Shoot();
            return Status.Success;
        }
        return Status.Failure;
    }

    protected override void OnEnd()
    {
    }
}

