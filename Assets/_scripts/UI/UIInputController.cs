using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputController : MonoBehaviour
{
    public event Action HandleGameSpeedIncrease = delegate { };
    public event Action HandleGameSpeedDecrease = delegate { };
    public event Action ToggleMenue = delegate { };

    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            HandleGameSpeedDecrease();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            HandleGameSpeedIncrease();
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            ToggleMenue();
        }
    }
}
