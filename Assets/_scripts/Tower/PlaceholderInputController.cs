using UnityEngine;

public class PlaceholderInputController : MonoBehaviour
{
    public event System.Action<Vector3> HandleMouse = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        this.HandleMouse(transform.position);
    }
}