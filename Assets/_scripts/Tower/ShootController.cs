using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private SOTower _tower;
    [SerializeField] private AudioSource shootSound;

    private float lastShot = 0;

    public SOTower Tower
    {
        get { return this._tower; }
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time >= this.lastShot + ( 1f / this._tower.AttackSpeed))
        {
            this.lastShot = Time.time;
            this.Shoot();
        }
    }

    private void Shoot()
    {
        Rigidbody p = Instantiate(this._tower.Shot, transform);
        p.velocity = transform.forward * this._tower.Velocity;
    }
}