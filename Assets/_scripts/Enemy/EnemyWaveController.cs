using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveController
{
    private List<Wave> waves;
    private int currentEnemyGroup = 0;
    private int currentEnemyNumber = 0;
    private int currentWave;
    public int CurrentWave {
        get { return currentWave; } set { currentWave = value; currentEnemyNumber = 0; currentEnemyGroup = 0; }
    }
    public float CurrentSpawnDelay
    {
        get { return waves[currentWave - 1].wave[currentEnemyGroup].spawnDelay; }
    }

    public EnemyWaveController(List<Wave> waves)
    {
        this.waves = waves;
        this.currentWave= 1;
    }

    //call AreAllEnemiesSpawned before calling this, otherwise null is returned
    public Rigidbody NextEnemy()
    {
        if (!AreAllEnemiesOfCurrentWaveSpawned())
        {
            EnemyGroup group = waves[currentWave - 1].wave[currentEnemyGroup];
            currentEnemyNumber++;

            //Go to next enemy group if all enemies are spawned for current group
            if (currentEnemyNumber >= group.amount)
            {
                currentEnemyNumber = 0;
                currentEnemyGroup += 1;
            }
            return group.enemy;
        }
        return null;
    }

    //Returns whether there are any enemies left to spawn
    public bool AreAllEnemiesOfCurrentWaveSpawned()
    {
        return !(currentEnemyGroup < waves[currentWave - 1].wave.Count);
    }
}
