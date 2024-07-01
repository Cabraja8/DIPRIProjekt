using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{   
    public Transform ShotPoint;
    public GameObject EnemyProjectile;

    // Start is called before the first frame update
   protected override  void Start()
    {
    
      base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

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
                attackTime = Time.time + TimeBetweenAttacks;
            }
        }
    }

     public void RangedAttack()
    {
        if (target != null)
        {
            Vector2 direction = target.position - ShotPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            GameObject projectile = Instantiate(EnemyProjectile, ShotPoint.position, Quaternion.identity);
            projectile.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);

            EnemyProjectile projectileScript = projectile.GetComponent<EnemyProjectile>();
            if (projectileScript != null)
            {
                projectileScript.StartMoving(direction);
            }
        }
    }
}
