using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathController : MonoBehaviour
{
    [SerializeField] private float explosionForce = 7f;
    [SerializeField] private float explosionRadius = 5f;
    private IHealthController healthController;

    public event Action HandleBaseDeath = delegate { };

    private void Awake()
    {
        healthController = GetComponent<IHealthController>();
    }

    private void OnEnable() {
        healthController.HandleDeath += Die;
    }

    private void OnDisable() {
        healthController.HandleDeath -= Die;
    }

    private void Die()
    {
        HandleBaseDeath();
        Explode();
    }

    private void Explode()
    {
        IList meshObjects = new List<Transform>();
        foreach (Transform singleObject in transform) {
            meshObjects.Add(singleObject);
        }  
          
        transform.DetachChildren();
        foreach (Transform singleObject in meshObjects)
        {
            Rigidbody rigidBody = singleObject.gameObject.GetComponent<Rigidbody>();
            if (rigidBody == null) {
                rigidBody = singleObject.gameObject.AddComponent<Rigidbody>();
            }
                
            rigidBody.AddExplosionForce(
                explosionForce, 
                this.transform.position, 
                explosionRadius, 
                0f, 
                mode: ForceMode.VelocityChange);

            Destroy(singleObject.gameObject, 1f);
        }
    }
}
