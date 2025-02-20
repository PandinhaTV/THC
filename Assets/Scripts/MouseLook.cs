using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensitivity = 1.5f;
    public float smoothing = 5f;
    

    private float xMousePos;
    private float smothedMousePos;

    private float currentLookingPos;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ModifyInput();
        MovePlayer();
        
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
    }

    void ModifyInput()
    {
        xMousePos *= MouseSensitivity * smoothing;
        smothedMousePos = Mathf.Lerp(smothedMousePos, xMousePos, 1f / smoothing);
        

    }

    void MovePlayer()
    {
        currentLookingPos += smothedMousePos;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }
}
