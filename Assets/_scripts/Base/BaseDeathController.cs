using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathController : MonoBehaviour
{

    private BaseHealthController bhc;

    public event Action HandleBaseDeath = delegate { };

    private void Awake()
    {
        bhc = GetComponent<BaseHealthController>();
        bhc.HandleDeath += Die;
    }

    private void Die()
    {
        HandleBaseDeath();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
