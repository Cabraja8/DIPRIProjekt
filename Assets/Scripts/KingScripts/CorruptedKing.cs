using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptedKing : Enemy
{
    public int Damage;
   
    private float attack3Time;
    
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        DetectTarget();
        if (target != null)
        {
            GoTowardsTarget();
        }
        if (target == null)
        {
            return;
        }
    }

    protected override void GoTowardsTarget()
    {
        navMeshAgent.SetDestination(target.position);
        if (Vector2.Distance(transform.position, target.position) <= stopDistance)
        {
            if (Time.time >= attackTime)
            {
                if (ShouldPerformAttack3())
                {
                    StartCoroutine(PerformAttack3());
                }
                else
                {
                    PerformAttack();
                }
                attackTime = Time.time + TimeBetweenAttacks;
            }
        }
    }

    private void PerformAttack()
    {
        enemyAnimation.PlayAttackAnimation();
        Debug.Log("Attack");

        if (PlayerControls.isShieldActive)
        {
            Debug.Log("Defended by shield");
        }
        else
        {
            target.GetComponent<HealthManager>().TakeDamage(Damage);
        }
    }

    private bool ShouldPerformAttack3()
    {
   
        return Time.time >= attack3Time;
    }

    private IEnumerator PerformAttack3()
    {
        
        Debug.Log("Performing Attack3");

        Vector2 originalPosition = transform.position;
        Vector2 targetPosition = target.position;
        float percent = 0;

        while (percent <= 1)
        {
            percent += Time.deltaTime * attackSpeed;
            float smoothPercent = Mathf.SmoothStep(0f, 1f, percent);
            float formula = (-Mathf.Pow(smoothPercent, 1) + smoothPercent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }

        if (PlayerControls.isShieldActive)
        {
            Debug.Log("Defended by shield");
        }
        else
        {
            target.GetComponent<HealthManager>().TakeDamage(Damage * 2); 
        }
        
        attack3Time = Time.time + TimeBetweenAttacks; 
    }
}

