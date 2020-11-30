using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

    private IHealthController _hc;


    void Start()
    {
        _hc = GetComponent<IHealthController>();
        _hc.HandleDeath += PlayDeathSound;

    }

    private void OnDisable()
    {
        _hc.HandleDeath -= PlayDeathSound;
    }

    private void PlayDeathSound()
    {
        AudioSource src = Sound.PlayClipAt(enemy.DeathAudio, this.gameObject.transform.position);
        src.pitch = Sound.RandomPitch();
        src.volume = Sound.RandomVolume();
    }
}
