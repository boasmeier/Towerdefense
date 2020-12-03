using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSoundController : MonoBehaviour
{
    [SerializeField] private SOTower tower;

    IShootController _sc;
    private float pitch;
    private float volume;

    void Start()
    {
        _sc = GetComponent<IShootController>();
        _sc.HandleShoot += PlayShootSound;

        pitch = Sound.RandomPitch();
        //reduce volume of shoot sound
        volume = 0.3f * Sound.RandomVolume();
    }

    private void OnDisable()
    {
        _sc.HandleShoot -= PlayShootSound;
    }

    private void PlayShootSound()
    {
        AudioSource src = Sound.PlayClipAt(tower.ShootAudio, this.gameObject.transform.position);
        src.pitch = pitch;
        src.volume = volume;
    }
}
