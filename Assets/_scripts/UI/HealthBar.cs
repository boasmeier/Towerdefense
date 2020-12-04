using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public IHealthController healthController;
    public Slider slider;

    private void Awake() {
        healthController = GetComponentInParent<IHealthController>();
    }

    private void OnEnable()
    {
        healthController.HandlePercentageHealthChange += SetHealth;
    }

    private void OnDisable()
    {
        healthController.HandlePercentageHealthChange -= SetHealth;
    }

    private void SetHealth(float health)
    {
        slider.value = health;
    }
}
