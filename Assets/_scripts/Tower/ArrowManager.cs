using System;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    public Vector3 Position
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
    
    public int Rotation
    {
        set
        {
            if (arrow == null)
            {
                return;
            }
            arrow.transform.eulerAngles = new Vector3(90, 0, value);
        }
    }

}