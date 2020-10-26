using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SOLevel _level;

    public event Action<int> HandleBaseHealthChange = delegate { };
    public SOLevel Level
    {
        get { return this._level; }
    }

    private int money;
    private int remainingWaves;

    private BaseHealthController bhc;
    private BaseDeathController bdc;

    private void Awake()
    {
        bhc = FindObjectOfType<BaseHealthController>();
        bdc = FindObjectOfType<BaseDeathController>();
        bhc.HandleHealthChange += DisplayHealthChange;
        bdc.HandleBaseDeath += GameOver;
    }

    private void DisplayHealthChange(int newHealth)
    {
        HandleBaseHealthChange(newHealth);
    }

    private void GameOver() {
        // TODO
    }

    private void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.money = this._level.StartMoney;
        this.remainingWaves = this._level.TotalWaves;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
