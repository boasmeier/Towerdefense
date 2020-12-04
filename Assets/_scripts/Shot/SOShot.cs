using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shot", menuName = "Shot")]
public class SOShot : ScriptableObject
{
    [SerializeField] private int damage;
    public int Damage { get { return this.damage; } }
}
