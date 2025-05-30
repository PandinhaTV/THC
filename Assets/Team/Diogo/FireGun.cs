using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.InputSystem;
public class FireGun : MonoBehaviour
    {
        
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public AudioSource gunShotSound;
    public float fireRate = 0.2f;
    public InputActionProperty triggerAction;
    public Transform muzzle;
    
    
    private float nextFireTime = 0f;

    

    public void Update()
    {
        if (triggerAction.action.ReadValue<float>() > 0.1f && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    public void Fire()
    {
        if (bulletPrefab != null && muzzle != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.linearVelocity = muzzle.forward * bulletSpeed;
            gunShotSound?.Play();
        }

            
    }
}



