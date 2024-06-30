using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueDrop : MonoBehaviour
{
    public HealthManager healthManager;
    public GameObject weaponPrefab; // Assign a prefab for the weapon drop in the Inspector
    public WeaponTypeStatues weaponType; // Use WeaponTypeStatues instead of WeaponType

    void Start()
    {
        if (healthManager == null)
        {
            healthManager = GetComponent<HealthManager>();
        }
    }

    void Update()
    {
        if (healthManager != null && healthManager.currentHealth == 0)
        {   
            
            DropWeapon();
            Destroy(gameObject); // Destroy the statue after dropping the weapon
        }
    }

    void DropWeapon()
    {
        // Instantiate the weapon drop at the statue's position
        GameObject droppedWeapon = Instantiate(weaponPrefab, transform.position, Quaternion.identity);

        // Assign the weapon type to the dropped weapon
        WeaponFromStatue weapon = droppedWeapon.GetComponent<WeaponFromStatue>();
        if (weapon != null)
        {
            weapon.WeaponType = weaponType; // This will need to match the type in Weapon class
        }

        // Optionally add any additional logic for the dropped weapon
        Debug.Log("Dropped weapon of type: " + weaponType);
    }
}

