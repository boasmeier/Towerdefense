using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private static GameObject arrow;

    public static Vector3 position
    {
        set
        {
            if (arrow == null) {
                return;
            } else {
                value.y = 0.6f;
                arrow.transform.position = value;
            }
        }
    }
    
    public static int rotation
    {
        set
        {
            if (arrow == null) return;
            arrow.transform.eulerAngles = new Vector3(90, 0, value);
        }
    }

    private void Start()
    {
        arrow = GameObject.Find("PlaceholderArrow");
    }
}