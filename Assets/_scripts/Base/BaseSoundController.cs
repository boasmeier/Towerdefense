using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip lostHealthSound;
    [SerializeField] private AudioClip almostDeadSound;

    private BaseHealthController _hc;


    void OnEnable()
    {
        _hc = GetComponent<BaseHealthController>();
        _hc.HandleDeath += PlayDeathSound;
        _hc.HandleAlmostDead += PlayAlmostDeadSound;
        _hc.HandleHealthChange += PlayLostHealthSound;
    }

    void OnDisable()
    {
        _hc.HandleDeath -= PlayDeathSound;
        _hc.HandleAlmostDead -= PlayAlmostDeadSound;
        _hc.HandleHealthChange -= PlayLostHealthSound;
    }

    private void PlayDeathSound()
    {
        AudioSource src = Sound.PlayClipAt(deathSound, this.gameObject.transform.position);
    }
    private void PlayLostHealthSound(int h)
    {
        if(h != _hc.TotalHealth)
        {
            AudioSource src = Sound.PlayClipAt(lostHealthSound, this.gameObject.transform.position);
        }
    }

    private void PlayAlmostDeadSound()
    {
        AudioSource src = Sound.PlayRepeatingClipAt(almostDeadSound, this.gameObject.transform.position);
    }
}
