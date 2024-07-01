
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float regenRate = 8f; // brzina regeneracije
    public float regenDelay = 1f; // delay nakon zadnje "stete"
    private float lastDamageTime;

    public void Initialize()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        StartCoroutine(RegenerateHealth());
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(RegenerateHealth());
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
        lastDamageTime = Time.time;
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            if (Time.time - lastDamageTime > regenDelay && currentHealth < maxHealth)
            {
                currentHealth += Mathf.RoundToInt(regenRate * Time.deltaTime);
                if (currentHealth > maxHealth) currentHealth = maxHealth;
                if (healthBar != null)
                {
                    healthBar.SetHealth(currentHealth);
                }
            }
            yield return null;
        }
    }
}
