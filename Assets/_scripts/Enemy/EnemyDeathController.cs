using System;
using System.Collections;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;
    [SerializeField] private float shrinkTimeSec;
    private Animation anim;

    private IHealthController hc;

    public static Action<int> HandleEnemyDeath = delegate { };

    private void Awake()
    {
        anim = GetComponent<Animation>();
        anim.Stop();
        hc = GetComponent<IHealthController>();
        hc.HandleDeath += Die;
    }

    private void OnDisable()
    {
        hc.HandleDeath -= Die;
    }

    private void Die()
    {
        HandleEnemyDeath(enemy.Value);
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        anim.Play();
        yield return new WaitForSeconds(shrinkTimeSec);
        Destroy(gameObject);
    }
}