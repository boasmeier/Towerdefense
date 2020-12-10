using System;
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
        basis.HandleEnemyCollision += EnemyDestroyed;
        EnemyDeathController.HandleEnemyDeath += EnemyDied;
    }

    private void OnDisable()
    {
        //unsubscribe from events
        levelManager.SpawnWave -= NewWave;
        basis.HandleEnemyCollision -= EnemyDestroyed;
        EnemyDeathController.HandleEnemyDeath -= EnemyDied;
    }

    //Spawns next Enemy if available
    private void NextSpawn()
    {
        //As long as wave is not finished
        if (!waveController.AreAllEnemiesOfCurrentWaveSpawned())
        {
            float spawnDelay = waveController.CurrentSpawnDelay;
            EnemySpawn(waveController.NextEnemy());
            aliveEnemies += 1;
            Invoke("NextSpawn", UnityEngine.Random.Range(0.8f * spawnDelay, 1.2f * spawnDelay));
        }
    }

    private void NewWave(int wave)
    {
        waveController.CurrentWave = wave;
        NextSpawn();
    }

    private void EnemyDestroyed()
    {
        aliveEnemies -= 1;
        CheckWaveFinished();
    }

    private void EnemyDied(int value)
    {
        HandleEnemyDeath(value);
        EnemyDestroyed();
    }

    private void CheckWaveFinished()
    {
        if (waveController.AreAllEnemiesOfCurrentWaveSpawned() && aliveEnemies<=0)
        {
            HandleAllEnemiesOfWaveDied();
        }
    }
}
