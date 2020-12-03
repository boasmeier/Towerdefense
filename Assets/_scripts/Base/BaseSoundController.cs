using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSoundController : MonoBehaviour
{
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip lostHealthSound;
    [SerializeField] private AudioClip almostDeadSound;

    private BaseHealthController baseHealthController;


    private void OnEnable()
    {
        baseHealthController = GetComponent<BaseHealthController>();
        baseHealthController.HandleDeath += PlayDeathSound;
        baseHealthController.HandleAlmostDead += PlayAlmostDeadSound;
        baseHealthController.HandleHealthChange += PlayLostHealthSound;
    }

    private void OnDisable()
    {
        baseHealthController.HandleDeath -= PlayDeathSound;
        baseHealthController.HandleAlmostDead -= PlayAlmostDeadSound;
        baseHealthController.HandleHealthChange -= PlayLostHealthSound;
    }

    private void PlayDeathSound()
    {
        AudioSource src = Sound.PlayClipAt(deathSound, this.gameObject.transform.position);
    }

    private void PlayLostHealthSound(int h)
    {
        if(h != baseHealthController.TotalHealth)
        {
            AudioSource src = Sound.PlayClipAt(lostHealthSound, this.gameObject.transform.position);
        }
    }

    private void PlayAlmostDeadSound()
    {
        AudioSource src = Sound.PlayRepeatingClipAt(almostDeadSound, this.gameObject.transform.position);
    }
}
