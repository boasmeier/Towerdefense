using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

    private IHealthController healthControlle;

    private void Awake()
    {
        healthControlle = GetComponent<IHealthController>();
    }

    private void OnEnable() {
        healthControlle.HandleDeath += PlayDeathSound;
    }

    private void OnDisable()
    {
        healthControlle.HandleDeath -= PlayDeathSound;
    }

    private void PlayDeathSound()
    {
        AudioSource src = Sound.PlayClipAt(enemy.DeathAudio, this.gameObject.transform.position);
        src.pitch = Sound.RandomPitch();
        src.volume = Sound.RandomVolume();
    }
}
