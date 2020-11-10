using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputController : MonoBehaviour
{

    public event Action HandleGameSpeedIncrease = delegate { };
    public event Action HandleGameSpeedDecrease = delegate { };

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            this.HandleGameSpeedDecrease();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            this.HandleGameSpeedIncrease();
        }
    }
}
