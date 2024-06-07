using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Player
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        MovementSpeed = 5f;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        PlayerMove();
    }

    private void PlayerMove()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        PlayerControls playerControls = GetComponent<PlayerControls>();

          if (moveInput != Vector2.zero){
            PlayerAnimation.PlayWalkAnimation();
        }
        else{
            PlayerAnimation.StopWalkAnimation();
        }

        // if (playerControls != null && playerControls.isDashActive)
        // {
        //     moveInput = moveInput.normalized;
        // }

        // if (playerControls != null && playerControls.isSneakActive)
        // {
        //     moveInput = moveInput.normalized;
        // }

        MoveAmount = moveInput * MovementSpeed;
    }


    /// FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveAmount * Time.deltaTime);
    }
}
