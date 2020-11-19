﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private LevelManager lm;
    private float timeRemaining;
    private bool timerIsRunning = false;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private Text waveText;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private Button startWaveButton;
    [SerializeField]
    private Button menueButton;
    public event Action HandleWaveStart = delegate { };
    public event Action ToggleMenue = delegate { };

    private void Awake()
    {
        lm = FindObjectOfType<LevelManager>();
        startWaveButton.onClick.AddListener(ResetTimerDisplay);
        menueButton.onClick.AddListener(HandleMenueButton);
    }

    private void OnEnable() 
    {
        lm.HandleBaseHealthChange += DisplayHealth;
        lm.HandleMoneyChange += DisplayMoney;
        lm.HandleWaveChange += DisplayWave;
    }

    private void OnDisable() {
        lm.HandleBaseHealthChange -= DisplayHealth;
        lm.HandleMoneyChange -= DisplayMoney;
        lm.HandleWaveChange -= DisplayWave;
    }

    private void DisplayHealth(int newHealth)
    {
        healthText.text = "Health: " + newHealth;
    }
    private void DisplayMoney(int newMoney)
    {
        moneyText.text = "Money: " + newMoney;
    }

    private void DisplayWave(int cur, int tot)
    {
        waveText.text = "Waves: " + cur + "/" + tot;
        if(cur > 1) {
            timerIsRunning = true;
            timeRemaining = 30;
            Debug.Log("Start Timer!");
            startWaveButton.interactable = true;
        }
    }
    
    private void DisplayTimer(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = "Next wave: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void ResetTimerDisplay() {
        if(timerIsRunning) {
            timeRemaining = 0;
        } else {
            HandleWaveStart();
            startWaveButton.interactable = false;
        }
    }

    private void HandleMenueButton() {
        ToggleMenue();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out! Next wave has started!");
                timeRemaining = 0;
                timerIsRunning = false;
                startWaveButton.interactable = false;
                HandleWaveStart();
            }
            DisplayTimer(timeRemaining);
        }
    }
}
