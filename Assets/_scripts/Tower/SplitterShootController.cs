using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Accessibility;

public class SplitterShootController : MonoBehaviour, IShootController
{
    [SerializeField] private SOTower _tower;

    public event Action HandleShoot = delegate { };

    private float lastShot = 0;
    private bool shooting;
    private LevelManager lM;

    public SOTower Tower
    {
        get { return this._tower; }
    }

    public bool TimerExpired()
    {
        return Time.time >= this.lastShot + (1f / this._tower.AttackSpeed);
    }


    public void Shoot()
    {
        HandleShoot();
        this.CreateShot(transform.forward);
        this.CreateShot(transform.right);
        this.CreateShot(-transform.right);
    }

    public void StartShooting(int w)
    {
        this.shooting = true;
    }

    public void StopShooting(int wOld, int wNew)
    {
        this.shooting = false;
    }

    private void CreateShot(Vector3 direction)
    {
        Rigidbody p = Instantiate(this._tower.Shot, transform);
        p.velocity = direction * this._tower.Velocity;
    }

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
        if (!this.TimerExpired() || !shooting) return;
        this.lastShot = Time.time;
        this.Shoot();
    }
}