using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDeathController : MonoBehaviour
{

    private IHealthController bhc;

    public event Action HandleBaseDeath = delegate { };

    private void Awake()
    {
        bhc = GetComponent<IHealthController>();
    }

    private void OnEnable() {
        bhc.HandleDeath += Die;
    }

    private void OnDisable() {
        bhc.HandleDeath -= Die;
    }

    private void Die()
    {
        HandleBaseDeath();
        Destroy(gameObject);
    }
}
