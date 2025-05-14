using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KeypadPuzzle : MonoBehaviour
{
    [SerializeField] private string correctCode = "1234";
    [SerializeField] private int maxDigits = 4;
    [SerializeField] private UnityEvent onCodeCorrect;
    [SerializeField] private UnityEvent onCodeIncorrect;
    
    [Header("Feedback")]
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip incorrectSound;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private TextMeshPro displayText;
    
    private string currentInput = "";
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        UpdateDisplay();
    }

    public void ButtonPressed(string value)
    {
        if (currentInput.Length >= maxDigits) return;
        
        // Play button sound
        if (buttonSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(buttonSound);
        }
        
        currentInput += value;
        UpdateDisplay();
        
        // Check if code is complete
        if (currentInput.Length == maxDigits)
        {
            CheckCode();
        }
    }

    private void CheckCode()
    {
        if (currentInput == correctCode)
        {
            // Correct code
            if (correctSound != null) audioSource.PlayOneShot(correctSound);
            onCodeCorrect.Invoke();
            Debug.Log("Codigo Certo" + currentInput);
        }
        else
        {
            // Incorrect code
            if (incorrectSound != null) audioSource.PlayOneShot(incorrectSound);
            onCodeIncorrect.Invoke();
            Debug.Log("Codigo Errado" + currentInput);
            ResetInput();
        }
    }

    public void ResetInput()
    {
        currentInput = "";
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        if (displayText != null)
        {
            // Show asterisks for privacy
            displayText.text = currentInput;
        }
    }
}