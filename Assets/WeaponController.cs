using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class WeaponController : MonoBehaviour
{
    public List<GameObject> weapons;
    public void SetWeapon(int i)
    {
        for (int index = 0; index < weapons.Count; index++)
    {
        bool isActive = (index == i);

        // Activate or deactivate the weapon GameObject
        weapons[index].SetActive(isActive);

        // Enable/disable all XR Interactors in this weapon
        var interactors = weapons[index].GetComponentsInChildren<XRBaseInteractor>(true);
        foreach (var interactor in interactors)
        {
            interactor.enabled = isActive;
        }

        // (Optional) Debug logging
        if (isActive)
        {
            Debug.Log("Switched to: " + weapons[index].name);
        }
    }
    }
}
