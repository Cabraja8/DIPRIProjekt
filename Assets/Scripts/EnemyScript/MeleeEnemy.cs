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
        
        base.Update();
        if (target != null)
        {
            AttackIfInRange();
        }
    }

   
      private void AttackIfInRange(){
        navMeshAgent.SetDestination(target.position);
        if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(target.position.x, target.position.y)) <= stopDistance)
{
    if (Time.time >= attackTime)
    {
    Debug.Log("Attack");

    enemyAnimation.PlayAttackAnimation();
        StartCoroutine(Attack());
        attackTime = Time.time + TimeBetweenAttacks;
    }
}
    }




IEnumerator Attack() {
    Vector2 originalPosition = transform.position;
    Vector2 targetPosition = target.position;
    float percent = 0;

    while (percent <= 1) {
        percent += Time.deltaTime * attackSpeed;
        float smoothPercent = Mathf.SmoothStep(0f, 1f, percent);
        float formula = (-Mathf.Pow(smoothPercent, 2) + smoothPercent) * 4;
        transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
        yield return null;
    }
}
}
