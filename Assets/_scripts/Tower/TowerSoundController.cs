using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSoundController : MonoBehaviour
{
    [SerializeField] private SOTower _tower;

    IShootController shootController;
    private float pitch;
    private float volume;

    private void Awake() {
        shootController = GetComponent<IShootController>();
    }

    void Start()
    {
        pitch = Sound.RandomPitch();
        //reduce volume of shoot sound
        volume = 0.3f * Sound.RandomVolume();
    }

    private void OnEnable() 
    {
        shootController.HandleShoot += PlayShootSound;
    }

    private void OnDisable()
    {
        shootController.HandleShoot -= PlayShootSound;
    }

    private void PlayShootSound()
    {
        AudioSource src = Sound.PlayClipAt(_tower.ShootAudio, gameObject.transform.position);
        src.pitch = pitch;
        src.volume = volume;
    }
}
