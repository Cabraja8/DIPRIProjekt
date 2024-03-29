using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    public float MovementSpeed;
    public Rigidbody2D rb;
    public Vector2 MoveAmount;
    // Start is called before the first frame update
     public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

 
}
