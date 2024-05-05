using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAndMovement : MonoBehaviour
{
    private Animator animator;
    private static readonly int SpeedHash = Animator.StringToHash("Speed");

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayWalkAnimation()
    {

        animator.SetBool("IsWalking", true);
    }

    public void StopWalkAnimation()
    {

        animator.SetBool("IsWalking", false);
    }

    public void PlayAttackAnimation()
    {

        animator.SetTrigger("Attack");
    }
    public void PlayAttack3Animation()
    {

        animator.SetTrigger("Attack3");
    }

    public void PlayTakeHitAnimation()
    {

        animator.SetTrigger("Take_Hit");
    }

    public void PlayDashAnimation()
    {
        animator.SetTrigger("Dash");
    }

    public void PlayShieldAnimation()
    {
        animator.SetBool("IsShielding", true);
    }
    public void StopShieldAnimation()
    {
        animator.SetBool("IsShielding", false);
    }

    public void DeathAnimation()
    {
        animator.SetTrigger("Dead");
    }
    public void SetSpeed(float speed)
    {

        animator.SetFloat(SpeedHash, speed);
    }


    public void MeleeAttackEvent()
    {
        MeleeEnemy meleeEnemy = GetComponentInParent<MeleeEnemy>();

        if (meleeEnemy != null)
        {

            if (meleeEnemy.target.GetComponent<HealthManager>().currentHealth < 1)
            {
                if (meleeEnemy.target.tag == "Knight")
                {
                    meleeEnemy.target.GetComponent<NPCKnightBehaviour>().DeathHandler();
                }
                else if (meleeEnemy.target.tag == "Player")
                {
                    meleeEnemy.target.GetComponent<Player>().DeathHandler();
                    // Disable player movmeent treba nadodat kasnije
                }
                meleeEnemy.target = null;
            }
            else
            {
                meleeEnemy.target.GetComponentInChildren<CombatAndMovement>().PlayTakeHitAnimation();
            }
        }
    }

    public void MeleeAttackEventKnight()
    {
        NPCKnightBehaviour NPCKnight = GetComponentInParent<NPCKnightBehaviour>();

        if (NPCKnight != null)
        {
            if (NPCKnight.Target.GetComponent<HealthManager>().currentHealth < 1)
            {
                NPCKnight.Target.GetComponent<Enemy>().DeathHandler();
                NPCKnight.Target = null;
            }
            else
            {

                NPCKnight.Target.GetComponentInChildren<CombatAndMovement>().PlayTakeHitAnimation();
            }
        }
    }


    public void RangedAttackEvent()
    {
        RangedEnemy rangedEnemy = GetComponentInParent<RangedEnemy>();

        if (rangedEnemy != null)
        {
            rangedEnemy.RangedAttack();
            if (rangedEnemy.target.GetComponent<HealthManager>().currentHealth < 1)
            {
                if (rangedEnemy.target.tag == "Knight")
                {
                    rangedEnemy.target.GetComponent<NPCKnightBehaviour>().DeathHandler();
                }
                else if (rangedEnemy.target.tag == "Player")
                {
                    rangedEnemy.target.GetComponent<Player>().DeathHandler();

                }

                rangedEnemy.target = null;
            }
        }
    }
}
