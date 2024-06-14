using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimationController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 movementDirection = new Vector2(navMeshAgent.velocity.x, navMeshAgent.velocity.z);

        // Update animation based on movement direction
        UpdateAnimation(movementDirection);
    }

    private void UpdateAnimation(Vector2 movementDirection)
    {
        bool isMoving = movementDirection.magnitude > 0.1f;

        if (isMoving)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            angle = (angle + 360) % 360; // Normalize angle to be between 0 and 360

            

            // Determine side movement (left or right) based on angle
            if ((angle >= 0 && angle < 45) || (angle >= 315 && angle < 360))
            {
               
                SetAnimatorParameters(false, true, false);
                spriteRenderer.flipX = true;
            }
            else if (angle > 135 && angle <= 225)
            {
                
                SetAnimatorParameters(false, true, false);
                spriteRenderer.flipX = false;
            }
            else if (angle >= 45 && angle < 135)
            {
               
                SetAnimatorParameters(true, false, false);
                spriteRenderer.flipX = false;
            }
            else if (angle > 225 && angle < 315)
            {
                
                SetAnimatorParameters(false, false, true);
                spriteRenderer.flipX = false;
            }
        }
        else
        {
            // Idle
            SetAnimatorParameters(false, false, false);
        }
    }

    private void SetAnimatorParameters(bool isWalkingDown, bool isSideWalking, bool isUpWalking)
    {
        animator.SetBool("IsWalkingDown", isWalkingDown);
        animator.SetBool("IsSideWalking", isSideWalking);
        animator.SetBool("IsUpWalking", isUpWalking);
    }
}






