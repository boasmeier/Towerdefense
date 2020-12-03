using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerButton : MonoBehaviour, ITowerSelector
{
    // Start is called before the first frame update
    [SerializeField] SOTower tower;
    [SerializeField] Text towerName;
    [SerializeField] Button towerButton;

    public event Action<int> HandleTowerSelected = delegate { };
    public event Action HandleTowerButtonClickSound = delegate { };

    void OnEnable()
    {
        towerName.text = "[" + this.tower.Id + "] " + this.tower.Name;
        towerButton.onClick.AddListener(() => HandleTowerSelected(this.tower.Id));
        towerButton.onClick.AddListener(() => HandleTowerButtonClickSound());
        EconomyController.TowerSelected += CheckIfSelected;
    }

    private void OnDisable()
    {
        EconomyController.TowerSelected -= CheckIfSelected;
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
