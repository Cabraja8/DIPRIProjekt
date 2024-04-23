using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
 
    // Start is called before the first frame update

    [Header("Player Movement Settings")]
    public float MovementSpeed;
    public Vector2 MoveAmount;
    // Start is called before the first frame update

    public CombatAndMovement PlayerAnimation;
    private SpriteRenderer rend;



    public virtual void Start()
    {   
       
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponentInChildren<CombatAndMovement>();
        rend = GetComponentInChildren<SpriteRenderer>();
    }


    public virtual void Update()
    {
        CheckWalkingAnimation();
        CheckAngle();
    }

    private void CheckAngle()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float angle = Vector2.SignedAngle(Vector2.right, moveDirection);

        if (angle >= 90 || angle <= -90)
        {   //okretanje bez spriterenderera
            //transform.localScale = new Vector3(-1f, 1f, 1f);
            rend.flipX = true;
        }
        else
        {
            //okretanje bez spriterenderera
            // transform.localScale = new Vector3(1f, 1f, 1f);
            rend.flipX = false;
        }
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

    public void DeathHandler(){
        Debug.Log("Player is dead");
    }

  

}

