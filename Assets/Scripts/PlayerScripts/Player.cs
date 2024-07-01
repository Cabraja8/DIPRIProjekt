using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public GameObject HealthBarUI;
    public HealthManager healthManager;

    // Start is called before the first frame update

    [Header("Player Movement Settings")]
    public float MovementSpeed;
    public Vector2 MoveAmount;
    // Start is called before the first frame update

    public CombatAndMovement PlayerAnimation;
    private SpriteRenderer rend;
    public GameObject swordHitbox;
    Collider2D swordCollider;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponentInChildren<CombatAndMovement>();
        rend = GetComponentInChildren<SpriteRenderer>();
        swordCollider = swordHitbox.GetComponent<Collider2D>();
        // healthManager = GetComponent<HealthManager>();
        // healthManager.healthBar = HealthBarUI.GetComponent<HealthBar>();

        if (healthManager == null)
        {
            healthManager = GetComponent<HealthManager>();
        }

        if (healthManager != null && healthManager.healthBar == null)
        {
            healthManager.healthBar = HealthBarUI.GetComponent<HealthBar>();
        }

        // inicijalizacija helath manager
        if (healthManager != null)
        {
            healthManager.Initialize();
        }
    }

    public virtual void Update()
    {
        CheckAngle();
    }

    // private void CheckAngle()
    // {
    //     Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    //     if (moveDirection.x != 0)
    //     {
    //         if (moveDirection.x < 0)
    //         {
    //             rend.flipX = true;
    //         }
    //         else
    //         {
    //             rend.flipX = false;
    //         }
    //     }
    //     else
    //     {
    //         Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         mousePosition.z = 0f;
    //         Vector2 playerToMouse = mousePosition - transform.position;

    //         if (playerToMouse.x < 0)
    //         {
    //             rend.flipX = true;
    //         }
    //         else
    //         {
    //             rend.flipX = false;
    //         }
    //     }
    // }
    private void CheckAngle()
    {
        Vector2 moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveDirection.x != 0)
        {
            rend.flipX = moveDirection.x < 0;
        }
        else
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Vector2 playerToMouse = mousePosition - transform.position;

            rend.flipX = playerToMouse.x < 0;
        }
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
        if (healthManager != null)
        {
            healthManager.TakeDamage((int)damage);
            if (healthManager.currentHealth <= 0)
            {
                DeathHandler();
            }
        }
    }
}

