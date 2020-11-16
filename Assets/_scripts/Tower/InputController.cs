using System;
using UnityEngine;

public class InputController : MonoBehaviour, IArrowsInputController, ITowerSelector, ITowerBuyController
{
    public event Action HandleLeft = delegate { };

    public event Action HandleRight = delegate { };

    public event Action HandleUp = delegate { };

    public event Action HandleDown = delegate { };

    public event Action<int> HandleTowerSelected = delegate { };

    public event Action HandleTowerBuy = delegate { };

    // Update is called once per frame
    private void Update()
    {
        DetectInput();
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.HandleLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.HandleRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.HandleUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.HandleDown();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.HandleTowerSelected(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.HandleTowerSelected(2);
        }else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            this.HandleTowerBuy();
        }
        
    }
}