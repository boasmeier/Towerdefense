using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour, IHealthController
{
    [SerializeField] private SOEnemy enemy;

	private int currentHealth;
	private EnemyCollisionController enemyCollisionController;

	public event Action<int> HandleHealthChange = delegate { };
	public event Action HandleDeath = delegate { };
	public event Action<float> HandlePercentageHealthChange = delegate { };


	private void Awake()
	{
		currentHealth = enemy.Health;
		enemyCollisionController = GetComponent<EnemyCollisionController>();
	}

	private void OnEnable()
	{
		enemyCollisionController.HandleCollision += GetDamage;
	}

	private void OnDisable()
	{
		enemyCollisionController.HandleCollision -= GetDamage;
	}


	private void Start()
    {
		HandleHealthChange(currentHealth);
		HandlePercentageHealthChange(currentHealth / (float) enemy.Health);
    }

	//Gets called if collision is received by collisoncontroller
	private void GetDamage(int damage)
    {
		if(currentHealth > 0) {
			currentHealth -= damage;
			if(currentHealth < 0)
			{
				currentHealth = 0;
			}

			HandleHealthChange(currentHealth);
			HandlePercentageHealthChange(currentHealth / (float) enemy.Health);

			if (currentHealth <= 0)
			{
				HandleDeath();
			}
		}
	}
}
