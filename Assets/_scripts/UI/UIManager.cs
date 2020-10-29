using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private LevelManager lm;

    [SerializeField]
    private Text healthText;

    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private Text waveText;

    [SerializeField]
    private Text timerText;

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
        moneyText.text = "Balance: " + newMoney;
    }

    private void DisplayWave(int cur, int tot)
    {
        waveText.text = "Waves: " + cur + "/" + tot;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
