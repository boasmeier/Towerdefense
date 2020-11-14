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

    void Start()
    {
        towerName.text = "[" + this.tower.Id + "] " + this.tower.Name;
        towerButton.onClick.AddListener(() => HandleTowerSelected(this.tower.Id));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
