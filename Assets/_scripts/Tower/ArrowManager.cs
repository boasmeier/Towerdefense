using System;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    public Vector3 position
    {
        set
        {
            if (arrow == null) {
                Debug.Log("Postion Arrow is Null");
                return;
            } else {
                value.y = 0.6f;
                arrow.transform.position = value;
            }
        }
    }
    
    public int rotation
    {
        set
        {
            if (arrow == null)
            {
                Debug.Log("rotation Arrow is Null");

                return;
            }
            arrow.transform.eulerAngles = new Vector3(90, 0, value);
        }
    }

}