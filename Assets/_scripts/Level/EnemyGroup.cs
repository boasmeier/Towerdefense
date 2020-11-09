using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyGroup
{
    public Rigidbody enemy;
    public int amount;
    //delay between the spawning of the enemies in seconds
    public float spawnDelay = 2;
}

