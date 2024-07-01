using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifeTime;
    public int damageAmount;
    public float Speed;

    private Vector3 moveDirection;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void StartMoving(Vector3 direction)
    {
        moveDirection = direction.normalized;
    }

    void Update()
    {
        transform.position += moveDirection * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Knight"))
        {
            HealthManager healthManager = other.GetComponent<HealthManager>();
            if (healthManager != null)
            {
                healthManager.TakeDamage(damageAmount);
                other.GetComponentInChildren<CombatAndMovement>().PlayTakeHitAnimation();
                Destroy(gameObject);
            }
        }
    }
}

