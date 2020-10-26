using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollisionController : MonoBehaviour
{
    LayerMask enemyLayer;
    public event Action HandleCollision = delegate { };

    // Start is called before the first frame update
    void Start()
    {
        enemyLayer  = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(enemyLayer);
        if(collision.gameObject.layer == enemyLayer)
        {
            Debug.Log("Base collided");
            HandleCollision();
            Destroy(collision.gameObject);
        }
    }
}
