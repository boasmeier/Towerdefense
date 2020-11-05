using System.Collections;
using UnityEngine;
using UnityEngine.Accessibility;

public class ShootController : MonoBehaviour
{
    [SerializeField] private SOTower tower;
    [SerializeField] private AudioSource shootSound;

    private float lastShot;
    private bool shooting;
    private LevelManager lM;


    private void OnEnable()
    {
        lM = FindObjectOfType<LevelManager>();
        shooting = lM.Running;
        lM.HandleWaveChange += StopShooting;
        lM.SpawnWave += StartShooting;
    }

    private void OnDisable()
    {
        lM.HandleWaveChange -= StopShooting;
        lM.SpawnWave -= StartShooting;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time >= this.lastShot + ( 1f / this.tower.AttackSpeed))
        {
            this.lastShot = Time.time;
            if (shooting)
            {
                this.Shoot();
            }
        }
    }

    private void Shoot()
    {
        Rigidbody p = Instantiate(this.tower.Shot, transform);
        p.velocity = transform.forward * this.tower.Velocity;
    }

    //if new wave is spawned, start shooting
    private void StartShooting(int w)
    {
        shooting = true;
    }

    //if wave ended, stop shooting
    private void StopShooting(int wOld, int wNew)
    {
        shooting = false;
    }
}