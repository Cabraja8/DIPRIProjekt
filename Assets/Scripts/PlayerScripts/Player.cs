using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   

    public float MovementSpeed;
    public Rigidbody2D rb;
    Vector2 MoveAmount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
