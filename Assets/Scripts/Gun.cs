using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PlayerShoot.shootInput += Shoot;
    }

    public void Shoot()
    {
        Debug.Log("pew pew pew pew");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
