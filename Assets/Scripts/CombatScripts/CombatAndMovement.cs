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
        //AudioManager.Instance.PlaySFX("walk");
    }

    public void StopWalkAnimation()
    {

        animator.SetBool("IsWalking", false);
        //AudioManager.Instance.sfxSource.Stop();
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

        if (meleeEnemy != null && meleeEnemy.target != null)
        {
            HealthManager targetHealth = meleeEnemy.target.GetComponent<HealthManager>();
            if (targetHealth != null && targetHealth.currentHealth < 1)
            {
                if (meleeEnemy.target.CompareTag("Knight"))
                {
                    NPCKnightBehaviour knightBehaviour = meleeEnemy.target.GetComponent<NPCKnightBehaviour>();
                    if (knightBehaviour != null)
                    {
                        knightBehaviour.DeathHandler();
                    }
                }
                else if (meleeEnemy.target.CompareTag("Player"))
                {
                    Player player = meleeEnemy.target.GetComponent<Player>();
                    if (player != null)
                    {
                        player.DeathHandler();
                    }
                }
                meleeEnemy.target = null;
            }
            else
            {
                CombatAndMovement combatAndMovement = meleeEnemy.target.GetComponentInChildren<CombatAndMovement>();
                if (combatAndMovement != null)
                {
                    combatAndMovement.PlayTakeHitAnimation();
                }
            }
        }
    }
    public void MeleeAttackCorruptedKing()
    {
        CorruptedKing corruptedKing = GetComponentInParent<CorruptedKing>();

        if (corruptedKing != null && corruptedKing.target != null)
        {
            HealthManager targetHealth = corruptedKing.target.GetComponent<HealthManager>();
            if (targetHealth != null && targetHealth.currentHealth < 1)
            {
                if (corruptedKing.target.CompareTag("Knight"))
                {
                    NPCKnightBehaviour knightBehaviour = corruptedKing.target.GetComponent<NPCKnightBehaviour>();
                    if (knightBehaviour != null)
                    {
                        knightBehaviour.DeathHandler();
                    }
                }
                else if (corruptedKing.target.CompareTag("Player"))
                {
                    Player player = corruptedKing.target.GetComponent<Player>();
                    if (player != null)
                    {
                        player.DeathHandler();
                    }
                }
                corruptedKing.target = null;
            }
            else
            {
                CombatAndMovement combatAndMovement = corruptedKing.target.GetComponentInChildren<CombatAndMovement>();
                if (combatAndMovement != null)
                {
                    combatAndMovement.PlayTakeHitAnimation();
                }
            }
        }
    }

    public void MeleeAttackEventKnight()
    {
        NPCKnightBehaviour NPCKnight = GetComponentInParent<NPCKnightBehaviour>();

        if (NPCKnight != null && NPCKnight.Target.tag == "Dead")
        {
            NPCKnight.Target = null;
        }

        if (NPCKnight != null && NPCKnight.Target != null)
        {
            HealthManager targetHealth = NPCKnight.Target.GetComponent<HealthManager>();
            if (targetHealth != null && targetHealth.currentHealth < 1)
            {
                Enemy enemy = NPCKnight.Target.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.DeathHandler();
                }
                NPCKnight.Target = null;
            }
            else
            {
                CombatAndMovement combatAndMovement = NPCKnight.Target.GetComponentInChildren<CombatAndMovement>();
                if (combatAndMovement != null)
                {
                    combatAndMovement.PlayTakeHitAnimation();
                }
            }
        }
    }



    public void RangedAttackEvent()
    {
        RangedEnemy rangedEnemy = GetComponentInParent<RangedEnemy>();

        if (rangedEnemy != null && rangedEnemy.target != null)
        {
            rangedEnemy.RangedAttack();

            HealthManager targetHealth = rangedEnemy.target.GetComponent<HealthManager>();
            if (targetHealth != null && targetHealth.currentHealth < 1)
            {
                if (rangedEnemy.target.CompareTag("Knight"))
                {
                    NPCKnightBehaviour knightBehaviour = rangedEnemy.target.GetComponent<NPCKnightBehaviour>();
                    if (knightBehaviour != null)
                    {
                        knightBehaviour.DeathHandler();
                    }
                }
                else if (rangedEnemy.target.CompareTag("Player"))
                {
                    Player player = rangedEnemy.target.GetComponent<Player>();
                    if (player != null)
                    {
                        player.DeathHandler();
                    }
                }
                rangedEnemy.target = null;
            }
        }
    }


    public void MeleeAttackUndeadEvent()
    {
        Undead undead = GetComponentInParent<Undead>();

        if (undead != null && undead.target != null)
        {
            HealthManager targetHealth = undead.target.GetComponent<HealthManager>();
            if (targetHealth != null && targetHealth.currentHealth < 1)
            {
                if (undead.target.CompareTag("Player"))
                {
                    Player player = undead.target.GetComponent<Player>();
                    if (player != null)
                    {
                        player.DeathHandler();
                    }
                }
            }
            else
            {
                CombatAndMovement combatAndMovement = undead.target.GetComponentInChildren<CombatAndMovement>();
                if (combatAndMovement != null)
                {
                    combatAndMovement.PlayTakeHitAnimation();
                }
            }
        }
    }

}
