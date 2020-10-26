using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

    private EnemyHealthController hc;

    public Action<int> HandleEnemyDeath = delegate { };

    private void Awake()
    {
        hc = GetComponent<EnemyHealthController>();
        hc.HandleDeath += Die;
    }


    private void Die()
    {
        HandleEnemyDeath(enemy.Value);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
