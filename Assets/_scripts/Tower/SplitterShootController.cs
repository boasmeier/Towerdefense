using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Accessibility;

public class SplitterShootController : MonoBehaviour, IShootController
{
    [SerializeField] private SOTower tower;

    public event Action HandleShoot = delegate { };

    private float lastShot = 0;
    private bool shooting;
    private LevelManager levelManager;

    public SOTower Tower
    {
        get { return tower; }
    }

    public bool TimerExpired()
    {
        return Time.time >= lastShot + (1f / tower.AttackSpeed);
    }


    public void Shoot()
    {
        HandleShoot();
        CreateShot(transform.forward);
        CreateShot(transform.right);
        CreateShot(-transform.right);
    }

    public void StartShooting(int w)
    {
        shooting = true;
    }

    public void StopShooting(int wOld, int wNew)
    {
        shooting = false;
    }

    private void CreateShot(Vector3 direction)
    {
        Rigidbody p = Instantiate(tower.Shot, transform);
        p.velocity = direction * tower.Velocity;
    }

    private void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        levelManager.HandleWaveChange += StopShooting;
        levelManager.SpawnWave += StartShooting;
    }

    private void OnDisable()
    {
        levelManager.HandleWaveChange -= StopShooting;
        levelManager.SpawnWave -= StartShooting;
    }

    private void Start() {
        shooting = levelManager.Running;
    }

    private void Update()
    {
        if (!TimerExpired() || !shooting) {
            return;
        } else {
            lastShot = Time.time;
            Shoot();
        } 
    }
}