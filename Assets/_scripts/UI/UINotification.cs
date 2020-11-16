using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{

    [SerializeField]
    private RectTransform notificationPanel;

    [SerializeField]
    private Text notificationText;

    private float notificationDelay = 1.0f;

    private void OnEnable() {
        EconomyController.DisplayNotEnoughMoney += DisplayNotification;
    }

    private void OnDisable() {
        EconomyController.DisplayNotEnoughMoney -= DisplayNotification;
    }

    private void DisplayNotification(string text) {
        notificationPanel.gameObject.SetActive(true);
        notificationText.text = text;
        Invoke("HideNotification", notificationDelay*Time.timeScale);
    }

    private void HideNotification() {
        notificationPanel.gameObject.SetActive(false);
    }
}
