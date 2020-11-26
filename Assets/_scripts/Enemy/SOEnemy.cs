using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class SOEnemy : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int value;
    [SerializeField] private int speed;
    [SerializeField] private AudioClip deathAudio;

    public int Health { get { return health; }}
    public int Speed { get { return speed; }}
    public int Value { get { return value; } }
    public AudioClip DeathAudio { get { return deathAudio; } }
}
