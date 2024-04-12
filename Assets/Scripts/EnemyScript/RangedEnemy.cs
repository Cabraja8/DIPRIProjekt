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
    }

     protected override void GoTowardsTarget()
    {
        navMeshAgent.SetDestination(target.position);
       if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y)) <= stopDistance){
            if (Time.time >= attackTime){
                attackTime = Time.time + TimeBetweenAttacks;
                enemyAnimation.StopWalkAnimation();
                 enemyAnimation.PlayAttackAnimation();
                
            }
        }
    }

    public void RangedAttack()
    {   
        
        CalculateShoot();
        Instantiate(EnemyProjectile, ShotPoint.position, ShotPoint.rotation);
    }

    private void CalculateShoot()
    {
        Vector2 direction = target.position - ShotPoint.position;
        float angle = MathF.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        ShotPoint.rotation = rotation;
    }
}
