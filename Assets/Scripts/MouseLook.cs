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

    private float currentLookingPosX;
    private float currentLookingPosY;

    public Transform playerBody; // Assign the player's transform for horizontal rotation

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

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
        // Rotate the player left and right
        currentLookingPosX += smoothedMousePosX;
        playerBody.rotation = Quaternion.Euler(0f, currentLookingPosX, 0f);

        // Rotate the camera up and down
        currentLookingPosY -= smoothedMousePosY; // Invert Y-axis movement
        currentLookingPosY = Mathf.Clamp(currentLookingPosY, -90f, 90f); // Prevent flipping

        transform.localRotation = Quaternion.Euler(currentLookingPosY, 0f, 0f);
    }
}