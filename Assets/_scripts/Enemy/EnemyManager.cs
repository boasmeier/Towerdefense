using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private LevelManager levelManager;
    private BaseCollisionController basis;
    private EnemyWaveController waveController;
    private int aliveEnemies = 0;

    public Action<Rigidbody> EnemySpawn = delegate { };
    public Action<int> HandleEnemyDeath = delegate { };
    public Action HandleAllEnemiesOfWaveDied = delegate { };

    private void OnEnable()
    {
        //get objets to subscribe to
        levelManager = FindObjectOfType<LevelManager>();
        basis = FindObjectOfType<BaseCollisionController>();

        //create EnemyWaveController
        waveController = new EnemyWaveController(levelManager.Level.Waves);

        //subscribe to events
        levelManager.SpawnWave += NewWave;
        basis.HandleEnemyReachedBase += EnemyDestroyed;
        EnemyDeathController.HandleEnemyDeath += EnemyDied;
    }

    private void OnDisable()
    {
        //unsubscribe from events
        levelManager.SpawnWave -= NewWave;
        basis.HandleEnemyReachedBase -= EnemyDestroyed;
        EnemyDeathController.HandleEnemyDeath -= EnemyDied;
    }

    //Spawns next Enemy if available
    private void NextSpawn()
    {
        //As long as wave is not finished
        if (!waveController.AreAllEnemiesOfCurrentWaveSpawned())
        {
            EnemySpawn(waveController.NextEnemy());
            aliveEnemies += 1;
            Invoke("NextSpawn", UnityEngine.Random.Range(1f, 3f));
        }
    }

    private void NewWave(int wave)
    {
        Debug.Log("Wave " + wave + " will be spawned");
        waveController.CurrentWave = wave;
        NextSpawn();
    }

    private void EnemyDestroyed()
    {
        aliveEnemies -= 1;
        checkWaveFinished();
    }

    private void EnemyDied(int value)
    {
        HandleEnemyDeath(value);
        EnemyDestroyed();
    }

    private void checkWaveFinished()
    {
        if (waveController.AreAllEnemiesOfCurrentWaveSpawned() && aliveEnemies<=0)
        {
            Debug.Log("Wave " + waveController.CurrentWave +  " finished");
            HandleAllEnemiesOfWaveDied();
        }
    }
}
