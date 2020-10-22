using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    [SerializeField] private SOTower tower;
    [SerializeField] private AudioSource shootSound;

    private float lastShot;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(Time.time >= this.lastShot + ( 1f / this.tower.AttackSpeed))
        {
            print(this.tower.AttackSpeed);
            this.lastShot = Time.time;
            this.Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        Rigidbody p = Instantiate(this.tower.Shot, transform);
        p.velocity = transform.forward * 10;
    }
}