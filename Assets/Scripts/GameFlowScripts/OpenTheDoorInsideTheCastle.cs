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
        if (box == null)
        {
            Debug.LogError("BoxCollider2D component not found on " + gameObject.name);
        }

        CurrentDoor = GetComponent<SpriteRenderer>();
        if (CurrentDoor == null)
        {
            Debug.LogError("SpriteRenderer component not found on " + gameObject.name);
        }
    }

    public void OpenDoor()
    {
        if (OpenedGate == null)
        {
            Debug.LogError("OpenedGate sprite is not assigned.");
            return;
        }

        if (CurrentDoor != null)
        {
            CurrentDoor.sprite = OpenedGate;
        }

        if (box != null)
        {
            box.enabled = false;
        }
    }   

    public void CloseDoor()
    {
        if (ClosedGate == null)
        {
            Debug.LogError("ClosedGate sprite is not assigned.");
            return;
        }

        if (CurrentDoor != null)
        {
            CurrentDoor.sprite = ClosedGate;
        }

        if (box != null)
        {
            box.enabled = true;
        }
    }
}

