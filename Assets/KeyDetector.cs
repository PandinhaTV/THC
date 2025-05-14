using System;
using UnityEngine;
using TMPro;

public class KeyDetector : MonoBehaviour
{
    public TextMeshPro display;
    
    public KeyPadControll keyPadControll;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        display.text = "";
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KeypadButton"))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var keyFeedBack  = other.gameObject.GetComponent<KeyFeedback>();
                if (key.text == "X")
                {
                    if (display.text.Length > 0)
                        display.text =  display.text.Substring(0, display.text.Length - 1);
                }
                else if (key.text == "<")
                {
                    var accessGranted = false;
                    bool onlyNumbers = int.TryParse(display.text, out int value);

                    if (onlyNumbers == true && display.text.Length > 0)
                    {
                        accessGranted = keyPadControll.CheckIfCorrect(Convert.ToInt32(display.text));
                    }

                    if (accessGranted == true)
                    {
                        display.text = "Start";

                    }
                    else
                    {
                        display.text = "Retry";
                    }
                }
                else
                {
                    bool onlyNumbers = int.TryParse(display.text, out int value);
                    if (onlyNumbers == false)
                    {
                        display.text = "";
                    }
                    if (display.text.Length > 4)
                        display.text += key.text;
                }
                keyFeedBack.keyHit = true;
            }
        }
            
    }
}
    

