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
    private bool attacking = false;

    public float OriginalMovementSpeed;
    private GameObject attackArea = default;
    public GameObject aoeArea = default;

    private float basicAttackCooldown = 1f;
    private float dashCooldown = 5f;
    private float sneakCooldown = 7f;
    private float shieldCooldown = 7f;
    private float aoeCooldown = 7f;

    private float basicAttackTimer = 0f;
    private float dashTimer = 0f;
    private float sneakTimer = 0f;
    private float shieldTimer = 0f;
    private float aoeTimer = 0f;
    public float attackDamage = 10f;
    public int Damage;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OriginalMovementSpeed = base.MovementSpeed;
        attackArea = transform.GetChild(4).gameObject;
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


        if (Input.GetMouseButtonDown(0) && !attacking && !isCooldownActive(basicAttackTimer, basicAttackCooldown))
        {
            StartCoroutine(Attack());
            PlayerAnimation.PlayAttackAnimation();

            attackArea.SetActive(true);
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
        Invoke("ResetAoE", 1f);
    }

    private void ResetDash()
    {
        MovementSpeed = OriginalMovementSpeed;
        isDashing = false;
        dashTimer = Time.time;
    }


    private void ResetSneak()
    {
        MovementSpeed = OriginalMovementSpeed;
        isSneaking = false;
        sneakTimer = Time.time;
    }
    private void ResetShield()
    {
        Debug.Log("Shield expired");
        isShielding = false;
        PlayerAnimation.StopShieldAnimation();
        shieldTimer = Time.time;
    }
    private void ResetAoE()
    {
        Debug.Log("AoE expired");
        isAoEActive = false;
        aoeTimer = Time.time;
        // aoeArea.SetActive(false);
    }

    private IEnumerator Attack()
    {
        attacking = true;
        attackArea.SetActive(true);
        Debug.Log("Player attacking");

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackArea.transform.position, attackArea.transform.localScale, 0f);

        foreach (Collider2D enemyCollider in hitEnemies)
        {
            if (enemyCollider.CompareTag("Enemy"))
            {
                enemyCollider.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }

        yield return new WaitForSeconds(0.25f);

        attacking = false;

        basicAttackTimer = Time.time;
    }


    private bool isCooldownActive(float timer, float cooldown)
    {
        return Time.time - timer < cooldown;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && attacking)
        {

            other.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

}