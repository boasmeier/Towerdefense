using UnityEngine;

public class PlaceholderInputController : MonoBehaviour
{
    public static event System.Action<Vector3> HandleMouse = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
        HandleMouse += RemoveHighlight;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnMouseDown()
    {
        HandleMouse(transform.position);
        this.ChangeColor(Color.gray);
    }

    private void ChangeColor(Color color)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }

    private void RemoveHighlight(Vector3 position)
    {
        this.ChangeColor(Color.green);
    }
}