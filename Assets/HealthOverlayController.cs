using UnityEngine;

public class HealthOverlayController : MonoBehaviour
{
    public PlayerManager playerHealth;
    public float fadeStartThreshold = 0.3f; // 30% health
    public float fadeSpeed = 2f;

    private Material overlayMat;
    private Color baseColor = new Color(0.5f, 0.5f, 0.5f, 0f); // starts fully transparent

    void Start()
    {
        overlayMat = GetComponent<Renderer>().material;
        overlayMat.color = baseColor;
    }

    void Update()
    {
        float healthPercent = playerHealth.GetHealthPercent();
        float targetAlpha = (healthPercent < fadeStartThreshold)
            ? Mathf.Clamp01(1f - (healthPercent / fadeStartThreshold)) * 0.6f // max 60% opacity
            : 0f;

        Color targetColor = new Color(baseColor.r, baseColor.g, baseColor.b, targetAlpha);
        overlayMat.color = Color.Lerp(overlayMat.color, targetColor, Time.deltaTime * fadeSpeed);
    }
}