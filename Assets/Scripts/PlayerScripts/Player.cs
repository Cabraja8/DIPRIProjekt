using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject HealthBarUI;

    // Start is called before the first frame update

    [Header("Player Movement Settings")]
    public float MovementSpeed;
    public Vector2 MoveAmount;
    // Start is called before the first frame update

    public CombatAndMovement PlayerAnimation;
    private SpriteRenderer rend;
    public float maxHealth = 100f;
    private float currentHealth;

    public GameObject swordHitbox;
    Collider2D swordCollider;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponentInChildren<CombatAndMovement>();
        rend = GetComponentInChildren<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
    }

    public virtual void Update()
    {
        CheckWalkingAnimation();
        CheckAngle();
    }

    private void CheckAngle()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveDirection.x != 0)
        {
            if (moveDirection.x < 0)
            {
                rend.flipX = true;
            }
            else
            {
                rend.flipX = false;
            }
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector2 playerToMouse = mousePosition - transform.position;

            if (playerToMouse.x < 0)
            {
                rend.flipX = true;
            }
            else
            {
                rend.flipX = false;
            }
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

        MoveAmount = currentPosition;
    }

    public void DeathHandler()
    {
        Debug.Log("Player is dead");
        gameObject.tag = "Dead";
        GetComponent<Player>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        GetComponentInChildren<CombatAndMovement>().DeathAnimation();
        HealthBarUI.SetActive(false);
        // GAME OVER SCREEN!  FindObjectOfType mozes koristit za pozivat funkcije 
    }

    public void TakeDamage(float damage)
    {
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                DeathHandler();
            }
        }
    }
}

