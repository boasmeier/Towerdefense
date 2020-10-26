using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

	private int currentHealth;
	private EnemyCollisionController ecc;

	//not sure if this event is even needed
	public event Action<int> HandleHealthChange = delegate { };
	public event Action HandleDeath = delegate { };

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
    }

	//Gets called if collision is received by collisoncontroller
	private void GetDamage(int damage)
    {
		Debug.Log("lost health");
		currentHealth -= damage;
		HandleHealthChange(currentHealth);
		if(currentHealth <= 0)
        {
			HandleDeath();
        }
    }
}
