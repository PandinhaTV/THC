using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    public static Action shootInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootInput?.Invoke();
        }
    }
}
