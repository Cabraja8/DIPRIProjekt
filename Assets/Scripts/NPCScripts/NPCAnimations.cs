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
        Vector2 movementDirection = new Vector2(navMeshAgent.velocity.x, navMeshAgent.velocity.y);

        // Update animation based on movement direction
        UpdateAnimation(movementDirection);
    }

    private void UpdateAnimation(Vector2 movementDirection)
    {
        bool isWalkingDown = movementDirection.y < 0;
        bool isSideWalking = Mathf.Abs(movementDirection.x) > 0;
        bool isUpWalking = movementDirection.y > 0;
        bool isMovingRight = movementDirection.x > 0;

        // Update animator parameters
        animator.SetBool("IsWalkingDown", isWalkingDown && !isSideWalking);
        animator.SetBool("IsSideWalking", isSideWalking);
        animator.SetBool("IsUpWalking", isUpWalking && !isSideWalking);

        // Handle sprite flipping for right-side movement
        if (isSideWalking)
        {
            spriteRenderer.flipX = isMovingRight;
        }
    }
}
