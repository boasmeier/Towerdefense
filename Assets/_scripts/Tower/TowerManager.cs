using UnityEngine;

public class TowerManager: MonoBehaviour
{
    public Vector3 position { get; set; }
    private Quaternion _rotation;

    public int rotation
    {
        set { _rotation = Quaternion.AngleAxis(value, Vector3.up); }
    }

    public void Build(GameObject tower)
    {
        Instantiate(tower, position, _rotation);
    }
}