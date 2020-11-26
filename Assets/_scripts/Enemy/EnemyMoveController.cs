using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;
    private int nextPosition = 1;
    private List<Vector3> route;

    // Start is called before the first frame update
    void Start()
    {
       route = FindObjectOfType<LevelManager>().Level.Route;
    }

    // Update is called once per frame
    void Update()
    {

        if(nextPosition < route.Count)
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
}
