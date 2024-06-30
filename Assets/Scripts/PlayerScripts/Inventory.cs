using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxCapacity = 1; 
    public List<StoneType> stones = new List<StoneType>();
    public List<GameObject> crown = new List<GameObject>();
    public List<WeaponTypeStatues> Weapons = new List<WeaponTypeStatues>();


    public void AddStone(StoneType stoneType)
    {
        if (stones.Count < maxCapacity)
        {
            stones.Add(stoneType);
            Debug.Log("Stone added to inventory: " + stoneType);
        }
        else
        {
            Debug.Log("Inventory is full. Cannot add more stones.");
        }
    }

    public void RemoveStone(StoneType stoneType)
    {
        stones.Remove(stoneType);
        Debug.Log("Stone removed from inventory: " + stoneType);
    }

    public void AddCrown(GameObject Crown)
    {
        if (crown != null)
        {
            crown.Add(Crown);
            Debug.Log("Crown added to inventory");
            Crown.SetActive(false); 
        }
        else
        {
            Debug.LogWarning("Tried to add a null crown to inventory.");
        }
    }

    public bool Contains(GameObject item)
    {
        return crown.Contains(item);
    }

       public void AddWeapons(WeaponTypeStatues weaponType)
    {
        if (Weapons.Count < maxCapacity)
        {
            Weapons.Add(weaponType);
            Debug.Log("Weapon added: " + weaponType);
        }
        else
        {
            Debug.Log("Inventory is full.");
        }
    }

    public void RemoveWeapon(WeaponTypeStatues weaponType)
    {
        if (Weapons.Contains(weaponType))
        {
            Weapons.Remove(weaponType);
            Debug.Log("Weapon removed: " + weaponType);
        }
        else
        {
            Debug.Log("Weapon not found in inventory.");
        }
    }
}

