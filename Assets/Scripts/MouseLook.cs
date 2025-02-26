using System;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 1.5f;
    public float smoothing = 5f;
    

    private float xMousePos;
    private float yMousePos;
    
    private float smoothedMousePosX;
    private float smoothedMousePosY;

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
        MoveMouse();
        
    }

    void GetInput()
    {
        xMousePos = Input.GetAxisRaw("Mouse X");
        yMousePos = Input.GetAxisRaw("Mouse Y");
        
        
    }

    void ModifyInput()
    {
        xMousePos *= mouseSensitivity * smoothing;
        yMousePos *= mouseSensitivity * smoothing;
        smoothedMousePosX = Mathf.Lerp(smoothedMousePosX, xMousePos, 1f / smoothing);
        smoothedMousePosY = Mathf.Lerp(smoothedMousePosY, yMousePos, 1f / smoothing);
        

    }

    void MoveMouse()
    {
        currentLookingPos += smoothedMousePosX ;
        transform.localRotation = Quaternion.AngleAxis(currentLookingPos, transform.up);
    }
}
