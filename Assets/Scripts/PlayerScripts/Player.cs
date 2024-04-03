using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    [Header("Player Movement Settings")]
    public float MovementSpeed;
    public Vector2 MoveAmount;
    // Start is called before the first frame update

    public CombatAndMovement PlayerAnimation;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponentInChildren<CombatAndMovement>();

    }


    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interact with NPC");
        }

        CheckWalkingAnimation();
    }

    public void CheckWalkingAnimation()
    {
        Vector2 currentPosition = transform.position;
        float distance = Vector2.Distance(currentPosition, MoveAmount);

        if (distance > 0.01f)
        {
            PlayerAnimation.PlayWalkAnimation();
        }
        else
        {
            PlayerAnimation.StopWalkAnimation();
        }

        // Update previous position for the next frame
        MoveAmount = currentPosition;


    }

}

