using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Player
{
    private bool isWalking = false; // Variable to track walking state

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

        if (moveInput != Vector2.zero)
        {
            PlayerAnimation.PlayWalkAnimation();
            if (!isWalking)
            {
                isWalking = true;
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.PlaySFX("Walk");
                }
                else
                {
                    Debug.LogError("AudioManager instance is not set.");
                }
            }
        }
        else
        {
            PlayerAnimation.StopWalkAnimation();
            if (isWalking)
            {
                isWalking = false;
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.StopSFX("Walk");
                }
                else
                {
                    Debug.LogError("AudioManager instance is not set.");
                }
            }
        }

        MoveAmount = moveInput * MovementSpeed;
    }

    /// FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveAmount * Time.deltaTime);
    }
}
