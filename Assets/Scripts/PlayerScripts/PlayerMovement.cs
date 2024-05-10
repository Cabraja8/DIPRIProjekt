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
        MovementSpeed = 7f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        PlayerMove();
    }

    private void PlayerMove()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        Vector2 MoveInput = new Vector2(MoveX, MoveY);
        MoveAmount = MoveInput.normalized * MovementSpeed;
    }
    /// FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveAmount * Time.deltaTime);
    }
}
