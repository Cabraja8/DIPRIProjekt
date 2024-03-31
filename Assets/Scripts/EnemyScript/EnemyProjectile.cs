using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{   

    
    public Vector2 TargetPosition;
    public float lifeTime;
    public int DamageAmount;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {   
        TargetPosition = FindAnyObjectByType<PlayerMovement>().transform.position;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,TargetPosition)> .1f){
            transform.position = Vector2.MoveTowards(transform.position,TargetPosition,speed * Time.deltaTime);
            
        }else{
            Destroy(gameObject);
        }
    }


    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            Debug.Log("Player shot");
        }
    }
}
