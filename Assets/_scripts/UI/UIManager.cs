using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private LevelManager lm;
    private float timeRemaining = 30;
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

    public event Action HandleWaveStart = delegate { };

    private void Awake()
    {
        lm = FindObjectOfType<LevelManager>();
        lm.HandleBaseHealthChange += DisplayHealth;
        lm.HandleMoneyChange += DisplayMoney;
        lm.HandleWaveChange += DisplayWave;
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
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimer(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out! Next wave has started!");
                timeRemaining = 0;
                timerIsRunning = false;
                HandleWaveStart();
            }
        }
    }

    private void DisplayTimer(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = "Next wave in: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
