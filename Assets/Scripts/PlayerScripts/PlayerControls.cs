using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Player
{
    public bool isDashActive = false;
    public bool isSneakActive = false;
    public static bool isShieldActive = false;
    public bool isAoEActive = false;
    private bool isAttackActive = false;

    public float OriginalMovementSpeed;
    public GameObject attackArea;
    public GameObject aoeArea;

    private float basicAttackCooldown = 1f;
    private float dashCooldown = 1f;
    private float sneakCooldown = 1f;
    private float shieldCooldown = 1f;
    private float aoeCooldown = 1f;

    private float basicAttackTimer = 0f;
    private float dashTimer = 0f;
    private float sneakTimer = 0f;
    private float shieldTimer = 0f;
    private float aoeTimer = 0f;

    public int Damage;
    public float detectionRadius = 5f;
    public LayerMask targetLayerMask;
    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attackArea = transform.GetChild(5).gameObject;
        playerMovement = GetComponent<PlayerMovement>();
        OriginalMovementSpeed = playerMovement.MovementSpeed;
        aoeArea = transform.GetChild(6).gameObject;
        aoeArea.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCooldownActive(dashTimer, dashCooldown))
        {
            Dash();
            PlayerAnimation.PlayDashAnimation();
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCooldownActive(sneakTimer, sneakCooldown))
        {
            Sneak();
            PlayerAnimation.PlayWalkAnimation();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isCooldownActive(shieldTimer, shieldCooldown))
        {
            Shield();
            PlayerAnimation.PlayShieldAnimation();
        }


        if (Input.GetKeyDown(KeyCode.Q) && !isCooldownActive(aoeTimer, aoeCooldown))
        {
            AoE();
            PlayerAnimation.PlayAttack3Animation();

        }


        if (Input.GetMouseButtonDown(0) && !isAttackActive && !isCooldownActive(basicAttackTimer, basicAttackCooldown))
        {
            StartCoroutine(Attack());
            PlayerAnimation.PlayAttackAnimation();
        }
    }


    private void Dash()
    {
        if (!isDashActive)
        {
            Debug.Log("Dash!");
            MovementSpeed *= 2;
            isDashActive = true;
            Invoke("ResetDash", 0.5f);
        }
    }

    private void Sneak()
    {
        if (!isSneakActive)
        {
            Debug.Log("Sneak!");
            MovementSpeed /= 2f;
            isSneakActive = true;
            Invoke("ResetSneak", 0.5f);
        }
    }

    private void Shield()
    {
        if (!isShieldActive)
        {
            Debug.Log("Shield!");
            isShieldActive = true;
            Invoke("ResetShield", 2f);

        }
    }

    private void AoE()
    {
        Debug.Log("AoE!");
        isAoEActive = true;
        aoeArea.SetActive(true);

        Collider2D collider = Physics2D.OverlapBox(aoeArea.transform.position, aoeArea.transform.localScale, 0f);
        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                HealthManager healthManager = collider.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(Damage);
                    Debug.Log("Aoe hit: " + collider.name);
                    if (healthManager.currentHealth > 1)
                    {
                        collider.GetComponentInChildren<CombatAndMovement>().PlayTakeHitAnimation();
                    }
                    else
                    {
                        collider.GetComponent<Enemy>().DeathHandler();
                    }

                }
            }
        }
        Invoke("ResetAoE", 1f);
        isAoEActive = false;
    }


    private void ResetDash()
    {
        MovementSpeed = OriginalMovementSpeed;
        isDashActive = false;
        dashTimer = Time.time;
    }


    private void ResetSneak()
    {
        MovementSpeed = OriginalMovementSpeed;
        isSneakActive = false;
        sneakTimer = Time.time;
    }
    private void ResetShield()
    {
        Debug.Log("Shield expired");
        isShieldActive = false;
        PlayerAnimation.StopShieldAnimation();
        shieldTimer = Time.time;
    }
    private void ResetAoE()
    {
        Debug.Log("AoE expired");
        isAoEActive = false;
        aoeTimer = Time.time;
        aoeArea.SetActive(false);
    }

    private IEnumerator Attack()
    {
        isAttackActive = true;
        Debug.Log("Player attacking");
        attackArea.SetActive(true);

        Collider2D collider = Physics2D.OverlapBox(attackArea.transform.position, attackArea.transform.localScale, 0f);
        if (collider != null)
        {
            if (collider.CompareTag("Enemy"))
            {
                HealthManager healthManager = collider.GetComponent<HealthManager>();
                if (healthManager != null)
                {
                    healthManager.TakeDamage(Damage);
                    Debug.Log("Attacked: " + collider.name);
                    if (healthManager.currentHealth > 1)
                    {
                        collider.GetComponentInChildren<CombatAndMovement>().PlayTakeHitAnimation();
                    }
                    else
                    {
                        collider.GetComponent<Enemy>().DeathHandler();
                    }
                }
            }
        }

        yield return new WaitForSeconds(0.25f);
        isAttackActive = false;
        basicAttackTimer = Time.time;
    }

    private bool isCooldownActive(float timer, float cooldown)
    {
        return Time.time - timer < cooldown;
    }

}
