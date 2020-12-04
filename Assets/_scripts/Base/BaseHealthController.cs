using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthController : MonoBehaviour, IHealthController
{
    [SerializeField] private int totalHealth;

    private int currentHealth;
    private int healthTreshold;
    private BaseCollisionController baseCollisionController;

    public event Action<int> HandleHealthChange = delegate { };
    public event Action HandleDeath = delegate { };
    public event Action HandleAlmostDead = delegate { };
    public event Action<float> HandlePercentageHealthChange = delegate { };

    public int TotalHealth { get { return totalHealth; } }

    private void Awake()
    {
        currentHealth = this.totalHealth;
        baseCollisionController = GetComponent<BaseCollisionController>();
        this.healthTreshold = CalculateHealthThreshold();
    }

    private void OnEnable()
    {
        baseCollisionController.HandleEnemyCollision += GetDamage;
    }

    private void OnDisable()
    {
        baseCollisionController.HandleEnemyCollision -= GetDamage;
    }

    private void Start()
    {
        HandleHealthChange(currentHealth);
    }

    private void GetDamage()
    {
        currentHealth -= 1;
        HandleHealthChange(currentHealth);
        if (currentHealth == healthTreshold)
        {
            HandleAlmostDead();
        }
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }

    private int CalculateHealthThreshold()
    {
        return this.totalHealth < 2 ? 0 : this.totalHealth / 4;
    }
}
