using UnityEngine;

public class TowerController : MonoBehaviour
{
    public static Vector3 position { get; set; }
    private static Quaternion _rotation;

    public static int rotation
    {
        set { _rotation = Quaternion.AngleAxis(value, Vector3.up); }
    }

    public static void Build(GameObject tower)
    {
        Instantiate(tower, position, _rotation);
    }
}