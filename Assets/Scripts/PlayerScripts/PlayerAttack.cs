using System.Collections;
using UnityEngine;

public class PlayerAttack : Player
{
    private GameObject attackArea = default;
    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attackArea = transform.GetChild(0).gameObject;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0) && !attacking)
            StartCoroutine(Attack());

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private IEnumerator Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        Debug.Log("Player attacking");

        if (PlayerAnimation != null)
            PlayerAnimation.PlayAttackAnimation();

        yield return new WaitForSeconds(timeToAttack);
        attacking = false;
        attackArea.SetActive(attacking);
    }
}