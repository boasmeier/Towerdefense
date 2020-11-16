using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

    private IHealthController hc;

    public static Action<int> HandleEnemyDeath = delegate { };

    private void Awake()
    {
        hc = GetComponent<IHealthController>();
        hc.HandleDeath += Die;
    }

    private void OnDisable() {
        hc.HandleDeath -= Die;
    }


    private void Die()
    {
        HandleEnemyDeath(enemy.Value);
        Destroy(gameObject);
    }
}
