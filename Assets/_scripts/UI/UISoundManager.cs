using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    
    [SerializeField] private AudioClip hoverSound;
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioClip buySound;
    [SerializeField] private AudioClip countdownSound;
    [SerializeField] private AudioClip waveStartSound;

    private UIMenue uiMenue;
    private UIManager uIManager;
    private UITowerDirection uiTowerDirection;
    private UITowerBuy uiTowerBuy;
    private UITowerButton[] uiTowerButtonList;
    private UIButtonHoverHandler[] uiButtonHoverHandlerList;
    private EconomyManager economyManager;
    
    private void Awake() {
        uiMenue = FindObjectOfType<UIMenue>();
        uIManager = FindObjectOfType<UIManager>();
        uiTowerDirection = FindObjectOfType<UITowerDirection>();
        uiTowerBuy = FindObjectOfType<UITowerBuy>();
        uiTowerButtonList = FindObjectsOfType<UITowerButton>();
        uiButtonHoverHandlerList = FindObjectsOfType<UIButtonHoverHandler>();
        economyManager = FindObjectOfType<EconomyManager>();
    }

    private void OnEnable() {
        uiMenue.HandleMenueButtonClickSound += PlayClick;
        uIManager.HandleManagerButtonClickSound += PlayClick;
        uIManager.HandleCountdownSound += PlayCountdown;
        uIManager.HandleNextWaveSound += PlayWaveStart;
        uiTowerDirection.HandleTowerDirectionClickSound += PlayClick;
        uiTowerBuy.HandleTowerBuyClickSound += PlayBuy;
        foreach (UITowerButton handler in uiTowerButtonList) {
            handler.HandleTowerButtonClickSound += PlayClick;
        }
        foreach (UIButtonHoverHandler handler in uiButtonHoverHandlerList) {
            handler.HandleMenueButtonHoverSound += PlayHover;
        } 
        EconomyManager.HandleSound += PlayBuy;
    }

    private void OnDisable() {
        uiMenue.HandleMenueButtonClickSound -= PlayClick;
        uIManager.HandleManagerButtonClickSound -= PlayClick;
        uIManager.HandleCountdownSound -= PlayCountdown;
        uIManager.HandleNextWaveSound -= PlayWaveStart;
        uiTowerDirection.HandleTowerDirectionClickSound -= PlayClick;
        uiTowerBuy.HandleTowerBuyClickSound -= PlayBuy;
        foreach (UITowerButton handler in uiTowerButtonList) {
            handler.HandleTowerButtonClickSound -= PlayClick;
        }
        foreach (UIButtonHoverHandler handler in uiButtonHoverHandlerList) {
            handler.HandleMenueButtonHoverSound -= PlayHover;
        }
        EconomyManager.HandleSound -= PlayBuy;
    }

    private void PlayHover() {
        AudioSource src = Sound.PlayClipAt(hoverSound, this.gameObject.transform.position);
    }

    private void PlayClick() {
        AudioSource src = Sound.PlayClipAt(clickSound, this.gameObject.transform.position);
    }

    private void PlayBuy() {
        AudioSource src = Sound.PlayClipAt(buySound, this.gameObject.transform.position);
    }
    
    private void PlayCountdown() {
        AudioSource src = Sound.PlayClipAt(countdownSound, this.gameObject.transform.position);
    }
    private void PlayWaveStart() {
        AudioSource src = Sound.PlayClipAt(waveStartSound, this.gameObject.transform.position);
    }
}
