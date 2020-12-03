using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Accessibility;

public class ShootController : MonoBehaviour, IShootController
{
    [SerializeField] private SOTower _tower;

    public event Action HandleShoot = delegate { };

    private float lastShot = 0;
    private bool shooting;
    private LevelManager levelManager;

    public SOTower Tower
    {
        get { return this._tower; }
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

    public bool TimerExpired()
    {
        return Time.time >= this.lastShot + (1f / this._tower.AttackSpeed);
    }

    public void Shoot()
    {
        HandleShoot();
        Rigidbody p = Instantiate(this._tower.Shot, transform);
        p.velocity = transform.forward * this._tower.Velocity;
    }

    public void StartShooting(int w)
    {
        this.shooting = true;
    }

    public void StopShooting(int wOld, int wNew)
    {
        this.shooting = false;
    }

    private void Update()
    {
        if (!this.TimerExpired() || !shooting) return;
        this.lastShot = Time.time;
        this.Shoot();
    }
}