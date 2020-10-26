using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SOLevel _level;
    public SOLevel Level
    {
        get { return this._level; }
    }

    private int money;
    private int remainingWaves;
    // Start is called before the first frame update

    private void OnEnable()
    {

    }

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
