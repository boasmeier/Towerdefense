using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthController : MonoBehaviour, IHealthController
{
    [SerializeField] private int health;

    private int currentHealth;
    private int healthTreshold;
    private BaseCollisionController bcc;

    public event Action<int> HandleHealthChange = delegate { };
    public event Action HandleDeath = delegate { };
    public event Action HandleAlmostDead = delegate { };
    public event Action<float> HandlePercentageHealthChange = delegate { };

    private void Awake()
    {
        currentHealth = this.health;
        bcc = GetComponent<BaseCollisionController>();
        this.healthTreshold = CalculateHealthThreshold();
    }

    private void OnEnable()
    {
        bcc.HandleEnemyCollision += GetDamage;
    }

    private void OnDisable()
    {
        bcc.HandleEnemyCollision -= GetDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        HandleHealthChange(currentHealth);
    }

    //Gets called if collision is received by collisoncontroller
    private void GetDamage()
    {
        currentHealth -= 1;
        Debug.Log("Base lost health (current healt: " + currentHealth + ")");
        HandleHealthChange(currentHealth);
        if (currentHealth == healthTreshold)
        {
            HandleAlmostDead();
        }
        else if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private int CalculateHealthThreshold()
    {
        if (this.health < 2) return 0;
        return this.health / 4;
    }
}
