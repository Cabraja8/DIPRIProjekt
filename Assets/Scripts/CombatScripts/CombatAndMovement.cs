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
    public void PlayAttack3Animation(){
        animator.SetTrigger("Attack3");
    }

    public void PlayTakeHitAnimation()
    {
        
        animator.SetTrigger("Take_Hit");
    }

    public void PlayDashAnimation(){
        animator.SetTrigger("Dash");
    }

    public void PlayShieldAnimation(){
        animator.SetBool("IsShielding", true);
    }
    public void StopShieldAnimation(){
        animator.SetBool("IsShielding", false);
    }

    public void DeathAnimation(){
        animator.SetBool("Dead", true);
    }
    public void SetSpeed(float speed)
    {
       
        animator.SetFloat(SpeedHash, speed);
    }


    public void MeleeAttackEvent(){
        MeleeEnemy meleeEnemy = GetComponentInParent<MeleeEnemy>();
        
        if (meleeEnemy != null)
        {
            meleeEnemy.StartCoroutine(meleeEnemy.Attack());
        }
    }

      public void RangedAttackEvent()
    {
        RangedEnemy rangedEnemy = GetComponentInParent<RangedEnemy>();
        
        if (rangedEnemy != null)
        {
           rangedEnemy.RangedAttack();
        }
    }
}
