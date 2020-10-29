using UnityEngine;

public class MapCollisionController : MonoBehaviour
{
    private LayerMask shotLayer;

    //public event Action<int> HandleCollision = delegate { };
    // Start is called before the first frame update
    private void Start()
    {
        shotLayer = LayerMask.NameToLayer("Shot");
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == shotLayer)
        {
            Destroy(collision.gameObject);
        }
    }
}