using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionController : MonoBehaviour
{
    LayerMask enemyLayer;
    public event Action HandleCollision = delegate { };
    public event Action HandleEnemyReachedBase = delegate { };

    // Start is called before the first frame update
    void Awake()
    {
        enemyLayer  = LayerMask.NameToLayer("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(enemyLayer);
        if(collision.gameObject.layer == enemyLayer)
        {
            Debug.Log("Base collided");
            HandleCollision();
            HandleEnemyReachedBase();
            Destroy(collision.gameObject);
        }
    }
}
