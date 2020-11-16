using UnityEngine;

public class PlaceholderInputController : MonoBehaviour
{
    public static event System.Action<Vector3> HandleMouse = delegate { };

    [SerializeField] Material defaultMaterial;
    [SerializeField] Material highlightMaterial;

    // Start is called before the first frame update
    private void Start()
    {
        HandleMouse += RemoveHighlight;
    }


    private void OnMouseDown()
    {
        HandleMouse(transform.position);
        this.ChangeColor(highlightMaterial);
    }

    private void ChangeColor(Material material)
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.material = material;
        }
    }

    private void RemoveHighlight(Vector3 position)
    {
        this.ChangeColor(defaultMaterial);
    }
}