using System;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    private LayerMask shotLayer;

    public event Action<int> HandleCollision = delegate { };

    private void Start()
    {
        shotLayer = LayerMask.NameToLayer("Shot");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == shotLayer.value)
        {
            HandleCollision(collision.gameObject.GetComponentInParent<Shot>().Damage);
            Destroy(collision.gameObject);
        }
    }
}