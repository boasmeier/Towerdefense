using UnityEngine;

public class GlobalInputController : MonoBehaviour
{
    public event System.Action HandleLeft = delegate { };

    public event System.Action HandleRight = delegate { };

    public event System.Action HandleUp = delegate { };

    public event System.Action HandleDown = delegate { };

    public event System.Action HandleOne = delegate { };

    public event System.Action HandleTwo = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        DetectInput();
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Pressed Left Arrow");
            this.HandleLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Pressed Right Arrow");
            this.HandleRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Pressed Up Arrow");
            this.HandleUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Pressed Down Arrow");
            this.HandleDown();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Pressed Number 1");
            this.HandleOne();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Pressed Number 2");
            this.HandleTwo();
        }
    }
}