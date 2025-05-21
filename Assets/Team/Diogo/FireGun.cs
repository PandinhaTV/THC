using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class FireGun : MonoBehaviour 
{
    [Header("VR Settings")] public XRNode controllerNode;
    public Transform muzzle;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public AudioSource gunShotSound;

    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor;

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

    private void OnEnable()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.AddListener(OnActivate);
    }

    private void OnDisable()
    {
        var interactable = GetComponent<XRGrabInteractable>();
        interactable.activated.RemoveListener(OnActivate);
    }

    private void OnActivate(ActivateEventArgs args)
    {
        Fire();
    }
}


