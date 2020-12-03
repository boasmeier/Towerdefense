using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private Vector3 spawn;
    private LevelManager levelManager; 
    private EnemyManager enemyManager;

    private void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
        enemyManager = GetComponent<EnemyManager>();
    }

    private void Start() {
        spawn = levelManager.Level.Route[0];
    }

    private void OnEnable()
    {
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
