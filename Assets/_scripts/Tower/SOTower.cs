using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class SOTower : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string towerName;
    [SerializeField] private int price;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float velocity;
    [SerializeField] private Rigidbody shot;
    [SerializeField] private AudioClip shootAudio;
    [SerializeField] private Sprite previewImage;

    public int Price { get { return price; } }
    public float AttackSpeed { get { return attackSpeed; } }
    public float Velocity { get { return velocity; } }
    public Rigidbody Shot { get { return shot; } }
    public string Name { get { return towerName; } }
    public int Id { get { return id; } }
    public AudioClip ShootAudio { get { return shootAudio; } }
    public Sprite PreviewImage { get { return previewImage; } }
}