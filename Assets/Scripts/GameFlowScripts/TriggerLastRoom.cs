using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLastRoom : MonoBehaviour
{   
    public OpenTheDoorInsideTheCastle LastDoor;
    public TriggerStatues triggerStatues;
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   triggerStatues.enabled = false;
            Invoke("CloseDoor",2f);
        }
    }
    public void CloseDoor(){
      
        LastDoor.CloseDoor();

    }
}
