using System;
using UnityEngine;
using UnityEngine.UI;

public class UITowerBuy : MonoBehaviour, ITowerBuyController
{
    [SerializeField] Button buttonBuy;
    [SerializeField] Text textNoMoneyAvailable;

    public event Action HandleTowerBuy = delegate { };
    public event Action HandleTowerBuyClickSound = delegate { };

    private LevelManager levelManager;
    private SOTower selectedTower;

    private void OnEnable()
    {
        UIColors.Highlight(buttonBuy);
        levelManager = FindObjectOfType<LevelManager>();
        buttonBuy.onClick.AddListener(() => HandleTowerBuy());
        buttonBuy.onClick.AddListener(() => HandleTowerBuyClickSound());
        EconomyManager.TowerSelected += TowerSelected;
        levelManager.HandleMoneyChange += MoneyChanged;
    }

    private void OnDisable()
    {
        EconomyManager.TowerSelected -= TowerSelected;
        levelManager.HandleMoneyChange -= MoneyChanged;
    }

    private void TowerSelected(SOTower tower)
    {
        selectedTower = tower;
        CheckPrice();
    }

    private void MoneyChanged(int m)
    {
        CheckPrice();
    }

    private void CheckPrice()
    {
        if (levelManager.CheckIfEnoughMoney(selectedTower.Price))
        {
            buttonBuy.interactable = true;
            textNoMoneyAvailable.gameObject.SetActive(false);
        }
        else
        {
            buttonBuy.interactable = false;
            textNoMoneyAvailable.gameObject.SetActive(true);
        }
    }
}


