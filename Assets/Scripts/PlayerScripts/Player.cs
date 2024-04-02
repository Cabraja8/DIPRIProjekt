using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    public Rigidbody2D rb;

    [Header("Player Movement Settings")]
    public float MovementSpeed;
    public Vector2 MoveAmount;
    // Start is called before the first frame update
     public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    public virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Interact with NPC");
        }
    }

 
}
