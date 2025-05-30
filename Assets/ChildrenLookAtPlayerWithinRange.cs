using UnityEngine;

public class ChildrenLookAtPlayerWithinRange : MonoBehaviour
{
    [SerializeField] private Transform player;        // Assign the player transform
    [SerializeField] private float lookAtRange = 10f; // Max distance to trigger look-at

    private void Update()
    {
        if (player == null) return;

        foreach (Transform child in transform)
        {
            float distance = Vector3.Distance(child.position, player.position);

            if (distance <= lookAtRange)
            {
                child.LookAt(player);
            }
        }
    }
}