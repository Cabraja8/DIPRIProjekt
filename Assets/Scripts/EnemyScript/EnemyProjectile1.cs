using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile1 : MonoBehaviour
{
       private Transform target;
    public float lifeTime;
    public int damageAmount;
    public float Speed;

    private Vector3 moveDirection;
    

    // Start is called before the first frame update
    void Start()
    {      
        Destroy(gameObject, lifeTime);
       
    }

    // Update is called once per frame
 public void StartMoving(Vector3 direction)
    {
        moveDirection = direction;
    }

    void Update()
    {
        // Move the projectile in the assigned direction
        transform.position += moveDirection * Speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag=="Knight"){
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
