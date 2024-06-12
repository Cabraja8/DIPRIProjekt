using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRegen : MonoBehaviour
{
    public float regenRate = 2f; // Health regen per second
    public float regenDelay = 2f; // Time to wait after taking damage before starting regen
    private float lastDamageTime;
    private Player player;
    private HealthManager healthManager;
    private HealthBar healthBar;

    void Start()
    {
        player = GetComponent<Player>();
        lastDamageTime = Time.time;
        healthManager = GetComponent<HealthManager>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    void Update()
    {
        if (Time.time - lastDamageTime >= regenDelay)
        {
            RegenerateHealth();
        }
    }

    public void TookDamage()
    {
        lastDamageTime = Time.time;
        healthBar.SetDirection(false);
    }

    private void RegenerateHealth()
    {
        if (player.currentHealth < player.maxHealth)
        {
            player.currentHealth += regenRate * Time.deltaTime;
            if (player.currentHealth > player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
            }
            healthManager.SetHealth((int)player.currentHealth);

            // Ažuriramo HealthBar
            healthBar.SetHealth((int)player.currentHealth);
            healthBar.SetDirection(true);
        }
    }
}
