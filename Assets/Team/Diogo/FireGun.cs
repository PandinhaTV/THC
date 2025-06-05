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
    private float fireRate = 2f;
    public InputActionProperty triggerAction;
    public Transform muzzle;
    public LayerMask hitLayers; 
    public Transform laser;
    public int powerup = 0;
    private float nextFireTime = 0f;

    public LineRenderer lineRenderer;     // Assign in Inspector
    public float laserLength = 100f;

    public void Update()
    {
        if (triggerAction.action.ReadValue<float>() > 0.1f && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }

        if (powerup == 1)
        {
            ShowLaser();
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

    public void PickUpPowerup()
    {
        Debug.Log("Picked up powerup");
        if (powerup == 0)
        {
            Debug.Log("Powerup 1");
            PowerupLaser();
            powerup += 1;
        }

        if (powerup >= 1)
        {
            Debug.Log("Powerup 2");
            PowerupRateofFire();
            powerup += 1;
        }
    }

    public void PowerupLaser()
    {
        ShowLaser();
    }
    
    public void PowerupRateofFire()
    {
        fireRate = 1f;
    }
    
    public void ShowLaser()
    {
        lineRenderer.enabled = true;

        Vector3 start = laser.position;
        Vector3 direction = laser.forward;
        Vector3 end = start + direction * laserLength;

        if (Physics.Raycast(start, direction, out RaycastHit hit, laserLength, hitLayers))
        {
            end = hit.point;
        }

        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }
    
}



