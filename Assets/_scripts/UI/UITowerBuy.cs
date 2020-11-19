using System;
using UnityEngine;
using UnityEngine.UI;

public class UITowerBuy : MonoBehaviour, ITowerBuyController
{
    [SerializeField] Button buttonBuy;

    public event Action HandleTowerBuy = delegate { };

    private LevelManager _lm;
    private SOTower selectedTower;

    void OnEnable()
    {
        UIColors.Highlight(buttonBuy);
        _lm = FindObjectOfType<LevelManager>();
        buttonBuy.onClick.AddListener(() => HandleTowerBuy());
        EconomyController.TowerSelected += TowerSelected;
        _lm.HandleMoneyChange += MoneyChanged;
    }

    void OnDisable()
    {
        EconomyController.TowerSelected -= TowerSelected;
        _lm.HandleMoneyChange -= MoneyChanged;
    }

    private void TowerSelected(SOTower tower)
    {
        selectedTower = tower;
        Debug.Log("Selected tower");
        CheckPrice();
    }

    private void MoneyChanged(int m)
    {
        CheckPrice();
    }

    private void CheckPrice()
    {
        if (_lm.CheckIfEnoughMoney(selectedTower.Price))
        {
            Debug.Log("Enable button");
            buttonBuy.interactable = true; 
        }
        else
        {
            Debug.Log("Disable button");
            buttonBuy.interactable = false;
        }
    }


}


