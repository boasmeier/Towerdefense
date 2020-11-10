﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SOLevel _level;

    public event Action<int> HandleBaseHealthChange = delegate { };
    public event Action<int> HandleMoneyChange = delegate { };
    public event Action<int, int> HandleWaveChange = delegate { };
    public event Action<int> SpawnWave = delegate { };
    public SOLevel Level
    {
        get { return this._level; }
    }
    public bool Running
    {
        get { return this._running; }
    }
    public bool CheckIfEnoughMoney(int availableMoney) 
    {
        return availableMoney<=this.money;
    }

    private bool _running;
    private int money;
    private int totalWave;
    private int currentWave;
    private int timer;

    private IHealthController bhc;
    private BaseDeathController bdc;
    private EnemyManager em;
    private UIManager uim;

    private void Awake()
    {
        bhc = FindObjectOfType<BaseHealthController>();
        bdc = FindObjectOfType<BaseDeathController>();
        em = FindObjectOfType<EnemyManager>();
        uim = FindObjectOfType<UIManager>();

        bhc.HandleHealthChange += DisplayHealthChange;
        bdc.HandleBaseDeath += GameOver;
        em.HandleEnemyDeath += DisplayMoneyChange;
        em.HandleAllEnemiesOfWaveDied += DisplayWaveChange;
        uim.HandleWaveStart += StartWave;
        EconomyController.HandleTowerBuyOrSell += DisplayMoneyChange;
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
        _running = false;

        if (this.currentWave < this.totalWave) {
            this.currentWave += 1;
            HandleWaveChange(this.currentWave, this.totalWave);
        }
    }

    private void GameOver() {
        _running = false;
    }

    private void StartWave() {
        _running = true;
        SpawnWave(currentWave);
    }

    // Start is called before the first frame update
    void Start()
    {
        this.money = this._level.StartMoney;
        this.totalWave = this._level.Waves.Count;
        this.currentWave = 1;
        HandleMoneyChange(money);
        HandleWaveChange(this.currentWave, this.totalWave);
    }
}

