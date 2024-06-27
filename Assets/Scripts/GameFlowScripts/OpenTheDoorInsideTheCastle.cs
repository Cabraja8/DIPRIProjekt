using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTheDoorInsideTheCastle : MonoBehaviour
{   
    public Sprite OpenedGate;
    public Sprite ClosedGate;

    public SpriteRenderer CurrentDoor;

    public BoxCollider2D box;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        CurrentDoor= GetComponent<SpriteRenderer>();
    }


    public void OpenDoor(){
        CurrentDoor.sprite= OpenedGate;
        box.enabled = false;
    }   

    public void CloseDoor(){
        CurrentDoor.sprite= ClosedGate;
        box.enabled = true;
    }


}
