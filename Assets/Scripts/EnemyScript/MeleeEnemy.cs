using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    // Start is called before the first frame update
     protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
  protected override  void Update()
    {   
         WalkEnemyAnim();
        base.Update();
        if (target != null)
        {
            AttackIfInRange();
        }
    }

     private void WalkEnemyAnim(){
    if (navMeshAgent.velocity.magnitude > 0.1f)
    {    
        enemyAnimation.PlayWalkAnimation();
    }
    else
    {
        enemyAnimation.StopWalkAnimation();
    }
}

      private void AttackIfInRange(){
        navMeshAgent.SetDestination(target.position);
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y)) <= stopDistance)
{
    if (Time.time >= attackTime)
    {
        StartCoroutine(Attack());
        attackTime = Time.time + TimeBetweenAttacks;
        enemyAnimation.StopWalkAnimation();
    }
}
    }




     IEnumerator Attack(){
    Vector2 originalPosition = transform.position;
    Vector2 targetPosition = target.position;
    float percent = 0;
    Debug.Log("Attack");
    enemyAnimation.PlayAttackAnimation();

    while (percent <= 1)
    {
        percent += Time.deltaTime * attackSpeed;
        float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
        transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
        yield return null;
    }
}
}
