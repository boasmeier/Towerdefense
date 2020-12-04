using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParticleController : MonoBehaviour
{
    private BaseCollisionController baseCollisionController;
    private BaseHealthController baseHealthController;
    [SerializeField] private ParticleSystem smokeParticles;
    [SerializeField] private ParticleSystem warningParticles;

    private void Awake()
    {
        baseCollisionController = GetComponent<BaseCollisionController>();
        baseHealthController = GetComponent<BaseHealthController>();
    }

    private void OnEnable()
    {
        baseCollisionController.HandleEnemyCollision += PlayWarning;
        baseHealthController.HandleAlmostDead += PlaySmoke;
    }

    private void OnDisable()
    {
        baseCollisionController.HandleEnemyCollision -= PlayWarning;
        baseHealthController.HandleAlmostDead -= PlaySmoke;
    }

    private void PlayWarning()
    {
        warningParticles.Play();
    }

    private void PlaySmoke()
    {
        smokeParticles.Play();
    }
}
