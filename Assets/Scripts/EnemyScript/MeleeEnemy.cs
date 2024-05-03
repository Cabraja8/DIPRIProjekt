using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    public int Damage;
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
                attackTime = Time.time + TimeBetweenAttacks;
            }
        }
    }


    public IEnumerator Attack()
    {
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
    }
}