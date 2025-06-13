using System;
using Unity.Behavior;
using UnityEngine;
using Unity.Properties;

#if UNITY_EDITOR
[CreateAssetMenu(menuName = "Behavior/Event Channels/EnemyDetected")]
#endif
[Serializable, GeneratePropertyBag]
[EventChannelDescription(name: "EnemyDetected", message: "[Agent] has spooted [Enemy]", category: "Events", id: "501e277c3afed84a04a07a1fc3fc7033")]
public sealed partial class EnemyDetected : EventChannel<GameObject, GameObject> { }

