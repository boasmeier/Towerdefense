using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerButton : MonoBehaviour, ITowerSelector
{
    [SerializeField] SOTower tower;
    [SerializeField] Text towerName;
    [SerializeField] Button towerButton;

    public event Action<int> HandleTowerSelected = delegate { };
    public event Action HandleTowerButtonClickSound = delegate { };

    private void Start() {
        towerName.text = "[" + this.tower.Id + "] " + this.tower.Name;
    }
    
    private void OnEnable()
    {
        towerButton.onClick.AddListener(() => HandleTowerSelected(this.tower.Id));
        towerButton.onClick.AddListener(() => HandleTowerButtonClickSound());
        EconomyManager.TowerSelected += CheckIfSelected;
    }

    private void OnDisable()
    {
        towerButton.onClick.RemoveListener(() => HandleTowerSelected(this.tower.Id));
        towerButton.onClick.RemoveListener(() => HandleTowerButtonClickSound());
        EconomyManager.TowerSelected -= CheckIfSelected;
    }

    private void CheckIfSelected(SOTower selectedTower)
    {
        if(selectedTower == tower)
        {
            UIColors.Highlight(towerButton);
        }
        else
        {
            UIColors.UnHighlight(towerButton);
        }
    }
}
