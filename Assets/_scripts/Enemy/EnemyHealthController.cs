using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IHealthController
{
    [SerializeField] private SOEnemy enemy;

	private int currentHealth;
	private EnemyCollisionController ecc;

	public event Action<int> HandleHealthChange = delegate { };
	public event Action HandleDeath = delegate { };
	public event Action<float> HandlePercentageHealthChange = delegate { };


	private void Awake()
	{
		currentHealth = enemy.Health;
		ecc = GetComponent<EnemyCollisionController>();
	}

	private void OnEnable()
	{
		ecc.HandleCollision += GetDamage;
	}

	private void OnDisable()
	{
		ecc.HandleCollision -= GetDamage;
	}


	void Start()
    {
		HandleHealthChange(currentHealth);
		HandlePercentageHealthChange(currentHealth / (float) enemy.Health);
    }

	//Gets called if collision is received by collisoncontroller
	private void GetDamage(int damage)
    {
		Debug.Log("lost health");
		currentHealth -= damage;
		HandleHealthChange(currentHealth);
		HandlePercentageHealthChange(currentHealth / (float) enemy.Health);
		if (currentHealth <= 0)
        {
			HandleDeath();
        }
    }
}
