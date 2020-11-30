using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSoundController : MonoBehaviour
{
    [SerializeField] private SOTower tower;

    IShootController _sc;

    void Start()
    {
        Debug.Log("Start Enemy Sound Controller");

        _sc = GetComponent<IShootController>();
        _sc.HandleShoot += PlayShootSound;
    }

    private void OnDisable()
    {
        _sc.HandleShoot -= PlayShootSound;
    }

    private void PlayShootSound()
    {
        AudioSource src = Sound.PlayClipAt(tower.ShootAudio, this.gameObject.transform.position);
        src.pitch = Random.Range(0.7f, 1.3f);
        src.volume = Random.Range(0.6f, 1.4f);
        src.spatialBlend = 0.6f;
    }
}
