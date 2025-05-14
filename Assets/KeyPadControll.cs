using UnityEngine;

public class KeyPadControll : MonoBehaviour
{
    public int correctCombination;

    public bool accessGranted = false;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (accessGranted == true)
        {
            accessGranted = false;
            Debug.Log("AccessGranted");
        }   
    }

    public bool CheckIfCorrect(int combination)
    {
        if (correctCombination == combination)
        {
            accessGranted = true;
            return true;
        }
        return false;
    }
}
