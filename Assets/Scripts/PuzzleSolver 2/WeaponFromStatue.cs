using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFromStatue : MonoBehaviour,Interactable
{   
    public  bool IsInteracted;
    public WeaponTypeStatues WeaponType;
    // Start is called before the first frame update

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        IsInteracted = false;
    }
    public void Interact()
    {
        IsInteracted = true;
         GameObject player = GameObject.FindGameObjectWithTag("Player");
        Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            if (inventory.Weapons.Count < inventory.maxCapacity)
            {
                inventory.AddWeapons(WeaponType);
                Destroy(gameObject); 
            }
            else
            {
                Debug.Log("Inventory is full. Cannot pick up more weapons.");
            }
        }
      
    }
    public bool CanInteract(){
       
        return !IsInteracted;
    }

}
