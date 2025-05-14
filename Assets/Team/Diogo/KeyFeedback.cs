using UnityEngine;

public class KeyFeedback : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audioClip;

    public bool keyHit = false;
    
    private Color originalColor;

    private Renderer renderer;

    private float colorReturnTime = 0.1f;

    private float returnColor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1.0f;
        audioSource.volume = 0.1f;
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (keyHit && returnColor < Time.time)
        {
            audioSource.PlayOneShot(audioClip);
            returnColor = Time.time + colorReturnTime;
            renderer.material.color = Color.green;
            keyHit = false;
        }

        if (renderer.material.color != originalColor && returnColor < Time.time)
        {
            renderer.material.color = originalColor;
        }
    }
}
