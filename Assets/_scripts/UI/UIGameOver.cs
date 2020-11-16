using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    private LevelManager lm;

    [SerializeField]
    private RectTransform gameOverPanel;
    [SerializeField]
    private Text gameOverText;

    public event Action ResetGameSpeed = delegate { };

    private void Awake()
    {
        lm = FindObjectOfType<LevelManager>();    
    }

    private void OnEnable() 
    {
        lm.HandleGameOver += DisplayGameOverMessage;
    }

    private void OnDisable() {
        lm.HandleGameOver -= DisplayGameOverMessage;
    }

    private void DisplayGameOverMessage(bool isWon) {
        gameOverPanel.gameObject.SetActive(true);
        gameOverText.text = isWon ? "YOU WON" : "YOU LOOSE";
        ResetGameSpeed();
    }
}
