using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthController : MonoBehaviour, IHealthController
{
    [SerializeField] private int health;

    private int currentHealth;
    private BaseCollisionController bcc;

    public event Action<int> HandleHealthChange = delegate { };
    public event Action HandleDeath = delegate { };
    public event Action<int> HandlePercentageHealthChange = delegate { };

    private void Awake()
    {
        currentHealth = this.health;
        bcc = GetComponent<BaseCollisionController>();
    }

    private void OnEnable()
    {
        bcc.HandleCollision += GetDamage;
    }

    private void OnDisable()
    {
        bcc.HandleCollision -= GetDamage;
    }

    // Start is called before the first frame update
    void Start()
    {
        HandleHealthChange(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Gets called if collision is received by collisoncontroller
    private void GetDamage()
    {
        currentHealth -= 1;
        Debug.Log("Base lost health (current healt: " + currentHealth + ")");
        HandleHealthChange(currentHealth);
        if (currentHealth <= 0)
        {
            HandleDeath();
        }
    }
}
