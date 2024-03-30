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

    public void PlayTakeHitAnimation()
    {
        
        animator.SetTrigger("TakeHit");
    }

    public void SetSpeed(float speed)
    {
       
        animator.SetFloat(SpeedHash, speed);
    }
}
