using UnityEngine;
[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class GunData : ScriptableObject
{
    public new string name;

    public float damage;
    public float maxDistance;
    
    public int currentAmmo;

    public int magSize;
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
