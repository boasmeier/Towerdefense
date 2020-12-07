using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionController : MonoBehaviour
{
    LayerMask enemyLayer;
    public event Action HandleEnemyCollision = delegate { };

    // Start is called before the first frame update
    private void Awake()
    {
        enemyLayer  = LayerMask.NameToLayer("Enemy");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == enemyLayer)
        {
            HandleEnemyCollision();
            Destroy(collision.gameObject);
        }
        Destroy(collision.gameObject);
    }
}
