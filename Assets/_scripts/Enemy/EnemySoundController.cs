using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundController : MonoBehaviour
{
    [SerializeField] private SOEnemy enemy;

    private EnemyHealthController _hc;


    void Start()
    {
        Debug.Log("Start Enemy Sound Controller");
        
        _hc = GetComponent<EnemyHealthController>();
        _hc.HandleDeath += PlayDeathSound;

    }

    private void OnDisable()
    {
        _hc.HandleDeath -= PlayDeathSound;
    }

    private void PlayDeathSound()
    {
        Debug.Log("Play Death Sound");
        AudioSource src = Sound.PlayClipAt(enemy.DeathAudio, this.gameObject.transform.position);
        src.pitch = Sound.RandomPitch();
        src.volume = Sound.RandomVolume();
    }
}
