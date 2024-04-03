using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Player
{
    // Dodatne varijable za akcije
    private bool isDashing = false;
    private bool isSneaking = false;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        PlayerControl();

    }
    private void PlayerControl()
    {
        float translation = Input.GetAxis("Horizontal") * MovementSpeed * Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
            PlayerAnimation.PlayWalkAnimation();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Sneak();
            PlayerAnimation.PlayWalkAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shield();
            PlayerAnimation.PlayAttackAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AoE();
            PlayerAnimation.PlayAttackAnimation();
        }
    }

    private void Dash()
    {

        if (!isDashing)
        {
            Debug.Log("Dash!");

            MovementSpeed *= 5f;
            isDashing = true;
            Invoke("ResetDash", 0.5f);
        }
    }

    private void Sneak()
    {
        if (!isSneaking)
        {
            Debug.Log("Sneak!");
            MovementSpeed /= 4f;
            isSneaking = true;
            Invoke("ResetSneak", 5f);
        }
    }

    private void Shield()
    {
        Debug.Log("Shield!");
    }

    private void AoE()
    {
        Debug.Log("AoE!");

    }

    private void ResetDash()
    {
        MovementSpeed = 5f;
        isDashing = false;
    }

    private void ResetSneak()
    {
        MovementSpeed = 5f;
        isSneaking = false;
    }


}

