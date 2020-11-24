using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParticleController : MonoBehaviour
{
    private BaseCollisionController bcc;
    private BaseHealthController bhc;
    [SerializeField] private ParticleSystem smokeParticles;
    [SerializeField] private ParticleSystem warningParticles;

    private void Awake()
    {
        bcc = GetComponent<BaseCollisionController>();
        bhc = GetComponent<BaseHealthController>();
    }

    private void OnEnable()
    {
        bcc.HandleEnemyCollision += PlayWarning;
        bhc.HandleAlmostDead += PlaySmoke;
    }

    private void OnDisable()
    {
        bcc.HandleEnemyCollision -= PlayWarning;
        bhc.HandleAlmostDead -= PlaySmoke;
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
