using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Player
{
    // Dodatne varijable za akcije
    public bool isDashing = false;
    public bool isSneaking = false;
    public bool isShielding = false;
    public bool isAoEActive = false;

    public float OriginalMovementSpeed;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OriginalMovementSpeed = base.MovementSpeed;

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
            PlayerAnimation.PlayDashAnimation();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Sneak();
            PlayerAnimation.PlayWalkAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shield();
            PlayerAnimation.PlayShieldAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            AoE();
            PlayerAnimation.PlayAttack3Animation();
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
        isShielding = true;
        Invoke("ResetShield", 5f);
    }

    private void AoE()
    {
        Debug.Log("AoE!");
        isAoEActive = true;
        Invoke("ResetAoe", 1f);

    }

    private void ResetDash()
    {
        MovementSpeed = OriginalMovementSpeed;
        isDashing = false;
    }


    private void ResetSneak()
    {
        MovementSpeed = OriginalMovementSpeed;
        isSneaking = false;
    }
    private void ResetShield()
    {
        Debug.Log("Shield expired");
        isShielding = false;
        PlayerAnimation.StopShieldAnimation();
    }
    private void ResetAoE()
    {
        Debug.Log("AoE expired");
        isAoEActive = false;

    }


}

