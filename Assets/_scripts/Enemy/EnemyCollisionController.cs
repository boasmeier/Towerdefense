using System;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private LayerMask shotLayer;

    public event Action<int> HandleCollision = delegate { };

    // Start is called before the first frame update
    private void Start()
    {
        shotLayer = LayerMask.NameToLayer("Shot");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == shotLayer)
        {
            HandleCollision(collision.gameObject.GetComponent<Shot>().Damage);
            Destroy(collision.gameObject);
        }
    }
}