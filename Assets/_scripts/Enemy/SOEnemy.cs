using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class SOEnemy : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int value;
    [SerializeField] private int speed;

    public int Health { get { return health; }}
    public int Speed { get { return speed; }}
    public int Value { get { return value; } }
}
