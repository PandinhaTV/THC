using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using UnityEngine.InputSystem;


    [Serializable, GeneratePropertyBag]
    [NodeDescription(name: "DetectTarget", story: "[Agent] detect [Target]", category: "Action",
        id: "be7f1864650ca0429ab8ceb204d98df8")]
    public partial class DetectTargetAction : Action
    {
        [SerializeReference] public BlackboardVariable<GameObject> Agent;
        [SerializeReference] public BlackboardVariable<GameObject> Target;

        NavMeshAgent agent;
        private Sensor sensor;

        protected override Status OnStart()
        {
            agent = Agent.Value.GetComponent<NavMeshAgent>();
            sensor = Agent.Value.GetComponent<Sensor>();
            return Status.Running;
        }

        protected override Status OnUpdate()
        {
            var target = sensor.GetClosestTarget("Player");
            if (target == null)
            {
                
                return Status.Failure;
            }

            Target.Value = target.gameObject;
            return Status.Success;
        }

        protected override void OnEnd()
        {
        }
    }


