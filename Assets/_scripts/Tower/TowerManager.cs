using UnityEngine;

public class TowerManager: MonoBehaviour
{
    public Vector3 Position { get; set; }
    private Quaternion _rotation;

    public int Rotation
    {
        set { _rotation = Quaternion.AngleAxis(value, Vector3.up); }
    }

    public void Build(GameObject tower)
    {
        Instantiate(tower, Position, _rotation);
    }
}