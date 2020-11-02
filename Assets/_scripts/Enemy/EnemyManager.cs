using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelManager levelManager;
    private BaseCollisionController basis;
    private List<Wave> waves;
    private int currentWave = 0;
    private int currentEnemyGroup = 0;
    private int currentEnemyNumber = 0;
    private int aliveEnemies = 0;
    private bool spawnFinished = false;

    public Action<Rigidbody> EnemySpawn = delegate { };
    public Action<int> HandleEnemyDeath = delegate { };
    public Action HandleAllEnemiesOfWaveDied = delegate { };

    private void OnEnable()
    {
        levelManager = FindObjectOfType<LevelManager>();
        basis = FindObjectOfType<BaseCollisionController>();

        waves = levelManager.Level.Waves;

        levelManager.SpawnWave += NewWave;
        basis.HandleEnemyReachedBase += EnemyReachedBase;
        EnemyDeathController.HandleEnemyDeath += EnemyDied;
    }

    private void OnDisable()
    {
        levelManager.SpawnWave -= NewWave;
    }

    void NextSpawn()
    {
        //As long as wave is not finished
        if (currentEnemyGroup < waves[currentWave - 1].wave.Count)
        {
            EnemyGroup group = waves[currentWave - 1].wave[currentEnemyGroup];
            EnemySpawn(group.enemy);
            aliveEnemies += 1;
            currentEnemyNumber++;
            //Go to next enemy group if all enemies are spawned for current group
            if (currentEnemyNumber >= group.amount)
            {
                currentEnemyNumber = 0;
                currentEnemyGroup += 1;
            }
            Invoke("NextSpawn", 2.0f);
        }
        else
        {
            spawnFinished = true;
        }
    }

    void NewWave(int wave)
    {
        spawnFinished = false;
        currentWave = wave;
        currentEnemyGroup = 0;
        currentEnemyNumber = 0;
        NextSpawn();
    }

    void EnemyReachedBase()
    {
        aliveEnemies -= 1;
        checkWaveFinished();
    }

    private void EnemyDied(int value)
    {
        aliveEnemies -= 1;
        HandleEnemyDeath(value);
        checkWaveFinished();
    }

    private void checkWaveFinished()
    {
        if (spawnFinished && aliveEnemies==0)
        {
            Debug.Log("Wave finished");
            HandleAllEnemiesOfWaveDied();
        }
    }
}
