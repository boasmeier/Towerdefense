using UnityEngine;

public class InputController : MonoBehaviour
{
    public event System.Action HandleLeft = delegate { };

    public event System.Action HandleRight = delegate { };

    public event System.Action HandleUp = delegate { };

    public event System.Action HandleDown = delegate { };

    public event System.Action<int> HandleNumber = delegate { };

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
            this.HandleNumber(1);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.HandleNumber(2);
        }
        
    }
}