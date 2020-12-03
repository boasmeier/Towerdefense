using UnityEngine;

public class MapCollisionController : MonoBehaviour
{
    private LayerMask shotLayer;

    private void Start()
    {
        shotLayer = LayerMask.NameToLayer("Shot");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == shotLayer)
        {
            Destroy(collision.gameObject);
        }
    }
}