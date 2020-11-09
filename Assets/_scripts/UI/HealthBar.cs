using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public IHealthController hc;
    public Slider slider;
    private void OnEnable()
    {
        hc = GetComponentInParent<IHealthController>();
        Debug.Log(hc.ToString());
        hc.HandlePercentageHealthChange += SetHealth;
    }

    private void OnDisable()
    {
        hc.HandlePercentageHealthChange -= SetHealth;
    }

    private void SetHealth(float health)
    {
        slider.value = health;
    }
}
