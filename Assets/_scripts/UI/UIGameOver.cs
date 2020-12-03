using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour
{
    private LevelManager levelManager;

    [SerializeField]
    private RectTransform gameOverPanel;
    [SerializeField]
    private Text gameOverText;

    private void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();    
    }

    private void OnEnable() 
    {
        levelManager.HandleGameOver += DisplayGameOverMessage;
    }

    private void OnDisable() {
        levelManager.HandleGameOver -= DisplayGameOverMessage;
    }

    private void DisplayGameOverMessage(bool isWon) {
        gameOverPanel.gameObject.SetActive(true);
        gameOverText.text = isWon ? "YOU WON" : "YOU LOSE";
    }
}
