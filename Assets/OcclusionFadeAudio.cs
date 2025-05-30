using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OcclusionFadeAudio : MonoBehaviour
{
    public Transform listener; // Assign your player or XR camera
    public float maxDistance = 20f;
    public LayerMask occlusionMask;

    private AudioSource audioSource;
    private float initialVolume;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        initialVolume = audioSource.volume;

        if (listener == null && Camera.main != null)
        {
            listener = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (listener == null) return;

        float distance = Vector3.Distance(transform.position, listener.position);

        // Line of sight check
        bool blocked = Physics.Linecast(transform.position, listener.position, occlusionMask);

        // Fade volume based on distance
        float fade = 1f - Mathf.InverseLerp(0, maxDistance, distance);

        // Reduce further if occluded
        if (blocked)
            fade *= 0.1f; // 90% quieter if behind a wall

        audioSource.volume = initialVolume * fade;
    }
}