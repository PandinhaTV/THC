using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable))]
public class VRKeypadButton : MonoBehaviour
{
    [SerializeField] private string buttonValue = "1";
    [SerializeField] private KeypadPuzzle keypadPuzzle;
    [SerializeField] private float pressDepth = 0.02f;
    [SerializeField] private AudioClip pressSound;

    private Vector3 originalPosition;
    private AudioSource audioSource;

    private void Awake()
    {
        originalPosition = transform.localPosition;
        audioSource = GetComponent<AudioSource>();
        
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        if (args.interactorObject is UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor)
        {
            SendHapticImpulse(controllerInteractor, 0.5f, 0.1f);
        }
        // Visual press effect
        transform.localPosition = originalPosition + (transform.forward * -pressDepth);
        
        // Play sound
        if (pressSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pressSound);
        }
        
        // Send value to keypad
        if (keypadPuzzle != null)
        {
            keypadPuzzle.ButtonPressed(buttonValue);
        }
        
        // Return button to original position
        Invoke("ResetButton", 0.1f);
    }

    
    private void SendHapticImpulse(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor controllerInteractor, float amplitude, float duration)
    {
        
        
        // New way to get the controller
        
            controllerInteractor.SendHapticImpulse(amplitude, duration);
        
    }
    private void ResetButton()
    {
        transform.localPosition = originalPosition;
    }
}