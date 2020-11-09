using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private Vector3 spawn;
    private LevelManager levelManager; 
    private EnemyManager enemyManager;

    private void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        enemyManager = GetComponent<EnemyManager>();
        spawn = levelManager.Level.Route[0];
        enemyManager.EnemySpawn += Spawn;
    }

    private void OnDisable()
    {
        enemyManager.EnemySpawn -= Spawn;
    }

    void Spawn(Rigidbody enemy)
    {
        Instantiate(enemy, spawn, Quaternion.identity);
    }
}
