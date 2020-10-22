using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SOLevel level;

    private int money;
    private int remainingWaves;
    // Start is called before the first frame update
    void Start()
    {
        this.money = this.level.StartMoney;
        this.remainingWaves = this.level.TotalWaves;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
