using UnityEngine;

public class TowerController : MonoBehaviour
{
    public static Vector3 position { get; set; }
    private static GameObject _tower { get; set; }
    private static Quaternion _rotation;

    public static int rotation
    {
        set { _rotation = Quaternion.AngleAxis(value, Vector3.up); }
    }

    public static GameObject tower
    {
        set { _tower = value; }
    }

    public static GameObject Build()
    {
        return Instantiate(_tower, position, _rotation);
    }
}