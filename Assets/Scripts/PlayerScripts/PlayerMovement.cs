using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : Player
{
    // Start is called before the first frame update
    public override void Start() {
    base.Start();
    }

      // Update is called once per frame
    void Update()
    {
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
