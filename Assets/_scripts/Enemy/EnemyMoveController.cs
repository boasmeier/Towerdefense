using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;
    private int nextPosition = 1;
    private bool alive = true;
    private List<Vector3> route;

    private IHealthController enemyHealthController;

    private void Awake()
    {

        enemyHealthController = GetComponent<IHealthController>();
        enemyHealthController.HandleDeath += Die;
        route = FindObjectOfType<LevelManager>().Level.Route;
    }

    // Update is called once per frame
    private void Update()
    {
        if(alive && nextPosition < route.Count)
        {
            float step = this.enemy.Speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, route[nextPosition],  step);

            // Check if the position of the enemy and the nextPosition are approximately equal.
            if (Vector3.Distance(transform.position, route[nextPosition]) < 0.001f)
            {
                nextPosition += 1;
            }
        }
    }

    private void Die()
    {
        alive = false;
    }
}
