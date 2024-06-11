using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    // public void TakeDamage(int damage)
    // {
    //     currentHealth -= damage;
    //     healthBar.SetHealth(currentHealth);
    // }

    //novi 
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
            currentHealth = 0;
        healthBar.SetHealth(currentHealth);
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthBar.SetHealth(currentHealth);
    }

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }
}
