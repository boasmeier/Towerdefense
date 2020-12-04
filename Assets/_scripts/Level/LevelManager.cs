﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SOLevel _level;

    public event Action<int> HandleBaseHealthChange = delegate { };
    public event Action<int> HandleMoneyChange = delegate { };
    public event Action<int, int> HandleWaveChange = delegate { };
    public event Action<int> SpawnWave = delegate { };
    public event Action<bool> HandleGameOver = delegate { };
    public event Action ResetGameSpeed = delegate { };
    public SOLevel Level
    {
        get { return _level; }
    }
    public bool Running
    {
        get { return running; }
    }
    public bool CheckIfEnoughMoney(int availableMoney)
    {
        return availableMoney <= money;
    }

    public bool IsWon;
    private bool running;
    private int money;
    private int totalWave;
    private int currentWave;
    private int timer;

    // Delay between game over/won and restart of scene in seconds
    private float restartDelay = 4f;

    private IHealthController healthController;
    private BaseDeathController baseDeathController;
    private EnemyManager enemyManager;
    private UIManager uiManager;
    private UIMenue uiMenue;

    private void Awake()
    {
        healthController = FindObjectOfType<BaseHealthController>();
        baseDeathController = FindObjectOfType<BaseDeathController>();
        enemyManager = FindObjectOfType<EnemyManager>();
        uiManager = FindObjectOfType<UIManager>();
        uiMenue = FindObjectOfType<UIMenue>();
    }

    private void OnEnable()
    {
        healthController.HandleHealthChange += DisplayHealthChange;
        baseDeathController.HandleBaseDeath += GameOver;
        enemyManager.HandleEnemyDeath += DisplayMoneyChange;
        enemyManager.HandleAllEnemiesOfWaveDied += DisplayWaveChange;
        uiManager.HandleWaveStart += StartWave;
        uiMenue.HandleRestart += Restart;
        EconomyManager.HandleTowerBuyOrSell += DisplayMoneyChange;
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    private void OnDisable()
    {
        healthController.HandleHealthChange -= DisplayHealthChange;
        baseDeathController.HandleBaseDeath -= GameOver;
        enemyManager.HandleEnemyDeath -= DisplayMoneyChange;
        enemyManager.HandleAllEnemiesOfWaveDied -= DisplayWaveChange;
        uiManager.HandleWaveStart -= StartWave;
        uiMenue.HandleRestart -= Restart;
        EconomyManager.HandleTowerBuyOrSell -= DisplayMoneyChange;
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    private void Start()
    {
        money = _level.StartMoney;
        totalWave = _level.Waves.Count;
        currentWave = 1;
        HandleMoneyChange(money);
        HandleWaveChange(currentWave, totalWave);
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode) 
    {
        totalWave = _level.Waves.Count;
        currentWave = 1;
        HandleWaveChange(currentWave, totalWave);
    }

    private void DisplayHealthChange(int newHealth)
    {
        HandleBaseHealthChange(newHealth);
    }

    private void DisplayMoneyChange(int money)
    {
        this.money += money;
        HandleMoneyChange(this.money);
    }

    private void DisplayWaveChange()
    {
        running = false;

        if (currentWave < totalWave)
        {
            currentWave += 1;
            HandleWaveChange(currentWave, totalWave);
        }
        else
        {
            IsWon = true;
            HandleGameOver(IsWon);
            Invoke("Restart", restartDelay * Time.timeScale);
        }
    }

    private void GameOver()
    {
        running = false;
        IsWon = false;
        HandleGameOver(IsWon);
        Invoke("Restart", restartDelay * Time.timeScale);
    }

    private void StartWave()
    {
        running = true;
        SpawnWave(currentWave);
    }

    private void Restart()
    {
        ResetGameSpeed();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

