﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerSelection : MonoBehaviour
{
    [SerializeField] Text towerName;
    [SerializeField] Text price;
    [SerializeField] Text speed;
    [SerializeField] Text damage;


    void OnEnable()
    {
        EconomyController.TowerSelected += TowerSelected;
    }

    void OnDisable()
    {
        EconomyController.TowerSelected -= TowerSelected;
    }

    void TowerSelected(SOTower tower)
    {
        Debug.Log("Tower selected in UITowerSelection");
        towerName.text = tower.Name;
        price.text = "Price: " + tower.Price + "$";
        speed.text = "Speed: " + tower.AttackSpeed;
        damage.text = "Damage: " + tower.Shot.GetComponent<Shot>().Damage;
    }
}
