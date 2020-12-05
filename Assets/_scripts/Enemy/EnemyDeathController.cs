using System;
using System.Collections;
using UnityEngine;

public class EnemyDeathController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;
    [SerializeField] private float shrinkTimeSec;
    private Animation anim;

    private IHealthController healthController;

    public static Action<int> HandleEnemyDeath = delegate { };

    private void Awake()
    {
        anim = GetComponent<Animation>();
        anim.Stop();
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
        Debug.Log("Shrink Enemy");
        gameObject.layer = LayerMask.NameToLayer("Default");
        anim.Play();
        yield return new WaitForSeconds(shrinkTimeSec);
        Destroy(gameObject);
    }
}