using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class SOTower : ScriptableObject
{
    [SerializeField] private string towerName;
    [SerializeField] private int price;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody shot;


    public int Price { get { return this.price; } }
    public float AttackSpeed { get { return this.attackSpeed; } }
    public float Velocity { get { return this.velocity; } }
    public Rigidbody Shot { get { return this.shot; } }
    public string Name { get { return this.towerName; } }
}