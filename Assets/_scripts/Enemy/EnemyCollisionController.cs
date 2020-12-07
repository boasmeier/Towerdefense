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
            var shot = collision.gameObject.GetComponentInParent<Shot>();
            if (!shot) return;
            HandleCollision(shot.Damage);
            Destroy(collision.gameObject);
        }
    }
}