using System;
using System.Collections;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;
    [SerializeField] private float shrinkTimeSec;
    private Animation animation;

    private IHealthController healthController;

    public static Action<int> HandleEnemyDeath = delegate { };

    private void Awake()
    {
        animation = GetComponent<Animation>();
        animation.Stop();
        healthController = GetComponent<IHealthController>();
        healthController.HandleDeath += Die;
    }

    private void OnDisable()
    {
        healthController.HandleDeath -= Die;
    }

    private void Die()
    {
        HandleEnemyDeath(enemy.Value);
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        animation.Play();
        yield return new WaitForSeconds(shrinkTimeSec);
        Destroy(gameObject);
    }
}