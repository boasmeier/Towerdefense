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

    private void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnEnable()
    {
        buttonBuy.onClick.AddListener(() => HandleTowerBuy());
        buttonBuy.onClick.AddListener(() => HandleTowerBuyClickSound());
        EconomyManager.TowerSelected += TowerSelected;
        levelManager.HandleMoneyChange += MoneyChanged;
    }

    private void Start() {
        UIColors.Highlight(buttonBuy);
    }

    private void OnDisable()
    {
        buttonBuy.onClick.RemoveListener(() => HandleTowerBuy());
        buttonBuy.onClick.RemoveListener(() => HandleTowerBuyClickSound());
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


