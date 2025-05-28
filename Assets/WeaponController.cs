using UnityEngine;
using System.Collections.Generic;
public class WeaponController : MonoBehaviour
{
    public List<GameObject> weapons;

    public void SetWeapon(int i)
    {
        if (i == 0)
        {
            Debug.Log("Hand");
            weapons[0].SetActive(true);
            weapons[1].SetActive(false);
        } 
        if (i == 1)
        {
            Debug.Log("Pistol");
            weapons[0].SetActive(false);
            weapons[1].SetActive(true);
        }
    }
}
