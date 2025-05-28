using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR;
public class RadialSelection : MonoBehaviour
{
    
    
    [Range(2,10)]
    public int numberofRadialPart;
    public GameObject RadialPartPrefab;

    public Transform radialPartCanvas;
    public float angleBetweenRadialParts = 10;
    public Transform handTransform;
    
    private List<GameObject> spawnedParts= new List<GameObject>();
    
    public UnityEvent<int> OnPartSelected;

    private int currentSelectedPart = -1;
    
    private InputDevice rightController;
    private bool previousButtonState = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TryInitializeController();
    }

    void TryInitializeController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);

        if (devices.Count > 0)
            rightController = devices[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!rightController.isValid)
        {
            TryInitializeController(); // Reacquire if lost
        }
        bool buttonValue;
        if (rightController.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue))
        {
            // Button just pressed
            if (buttonValue && !previousButtonState)
            {
                SpawnRadialPart();
            }

            // Button just released
            if (!buttonValue && previousButtonState)
            {
                GetSelectedRadialPart();
                HideAndTriggerSelected();
            }

            previousButtonState = buttonValue;
        }

        // Optional: keep updating selection highlight while the menu is active
        if (radialPartCanvas.gameObject.activeSelf)
        {
            GetSelectedRadialPart();
        }
    }

    public void HideAndTriggerSelected()
    {
        OnPartSelected.Invoke(currentSelectedPart);
        radialPartCanvas.gameObject.SetActive(false);
    }
    public void GetSelectedRadialPart()
    {
        Vector3 centerToHand = handTransform.position - radialPartCanvas.position;
        Vector3 centerToHandProjected = Vector3.ProjectOnPlane(centerToHand, radialPartCanvas.forward);
        
        float angle = Vector3.SignedAngle(radialPartCanvas.up,centerToHandProjected, -radialPartCanvas.forward);

        if (angle < 0)
        {
            angle += 360;
        }
        currentSelectedPart =(int) angle * numberofRadialPart / 360;

        for (int i = 0; i < spawnedParts.Count; i++)
        {
            if (i == currentSelectedPart)
            {
                spawnedParts[i].GetComponent<Image>().color = Color.red;
                spawnedParts[i].transform.localScale = 1.1f * Vector3.one;
            }
            else
            {
                spawnedParts[i].GetComponent<Image>().color = Color.white;
                spawnedParts[i].transform.localScale = Vector3.one;
            }
        }
    }
    public void SpawnRadialPart()
    {
        radialPartCanvas.gameObject.SetActive(true);
        radialPartCanvas.position = handTransform.position;
        radialPartCanvas.rotation = handTransform.rotation;
        foreach (var item in spawnedParts)
        {
            Destroy(item);
        }
        spawnedParts.Clear();
        for (int i = 0; i < numberofRadialPart; i++)
        {
            float angle = - i * 360 /  numberofRadialPart -  angleBetweenRadialParts/2 ;
            Vector3 radialPartEulerAngle = new Vector3(0, 0, angle);

            GameObject spawnedRadialPart = Instantiate(RadialPartPrefab, radialPartCanvas);
            spawnedRadialPart.transform.position = radialPartCanvas.position;
            spawnedRadialPart.transform.localEulerAngles = radialPartEulerAngle;

            spawnedRadialPart.GetComponent<Image>().fillAmount = 1 / ((float)numberofRadialPart) - (angleBetweenRadialParts / 360);
            
            spawnedParts.Add(spawnedRadialPart);
        }
    }
}

