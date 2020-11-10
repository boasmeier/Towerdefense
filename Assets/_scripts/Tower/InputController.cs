using UnityEngine;

public class InputController : MonoBehaviour
{
    public event System.Action HandleLeft = delegate { };

    public event System.Action HandleRight = delegate { };

    public event System.Action HandleUp = delegate { };

    public event System.Action HandleDown = delegate { };

    public event System.Action HandleOne = delegate { };

    public event System.Action HandleTwo = delegate { };

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
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            this.HandleOne();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            this.HandleTwo();
        }
        
    }
}