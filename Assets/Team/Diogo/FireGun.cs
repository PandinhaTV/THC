using System;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class FireGun : MonoBehaviour 
{
    [Header("VR Settings")] public XRNode controllerNode;
    private InputDevice controllerDevice;
    public float triggerThreshold = 0.5f;

    private bool triggerPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    protected void OnEnable()
    {

        controllerDevice = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    public void Update()
    {
        //if (!isSelected) return;

        controllerDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);

        if (triggerValue > triggerThreshold && !triggerPressed)
        {
            triggerPressed = true;
            TryShoot();
        }
        else if (triggerValue <= triggerThreshold && triggerPressed)
        {
            triggerPressed = false;
        }
    }

    private int currentAmmo;
    private float nextTimeToFire = 0f;
    public float fireRate = 0.2f;

    // Update is called once per frame
    private void TryShoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
            else
            {
                //gunAudio.PlayOneShot(emptySound);
                //StartCoroutine(Reload());
            }
        }
    }

    public void Shoot()
    {
        currentAmmo--;
        nextTimeToFire = Time.time + fireRate;

        //if (selectingInteractor is XRBaseController controller)
        //{
         //   controller.SendHapticImpulse(0.3f, 0.1f);
        //}
    }
}
