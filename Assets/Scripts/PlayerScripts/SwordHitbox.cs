
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitbox : MonoBehaviour
{
    public float swordDamage = 1f;
    public Collider2D swordCollider;

    // Start is called before the first frame update
    void Start()
    {
        if (swordCollider == null)
        {
            Debug.LogWarning("Sword collider not set");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        col.collider.SendMessage("onHit", swordDamage, SendMessageOptions.DontRequireReceiver);
    }


}
