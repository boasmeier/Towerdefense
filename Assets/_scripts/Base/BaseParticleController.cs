using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParticleController : MonoBehaviour
{
    private BaseHealthController baseHealthController;
    [SerializeField] private ParticleSystem smokeParticles;
    [SerializeField] private ParticleSystem warningParticles;

    private void Awake()
    {
        baseHealthController = GetComponent<BaseHealthController>();
    }

    private void OnEnable()
    {
        baseHealthController.HandleHealthChange += PlayWarning;
        baseHealthController.HandleAlmostDead += PlaySmoke;
    }

    private void OnDisable()
    {
        baseHealthController.HandleHealthChange -= PlayWarning;
        baseHealthController.HandleAlmostDead -= PlaySmoke;
    }

    private void PlayWarning(int h)
    {
        if (h != baseHealthController.TotalHealth)
        {
            warningParticles.Play();
        }
    }

    private void PlaySmoke()
    {
        smokeParticles.Play();
    }
}
