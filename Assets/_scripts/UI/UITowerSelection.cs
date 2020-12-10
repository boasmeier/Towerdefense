using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerSelection : MonoBehaviour
{
    [SerializeField] Text towerName;
    [SerializeField] Text price;
    [SerializeField] Text speed;
    [SerializeField] Text damage;
    [SerializeField] Image preview;

    private void OnEnable()
    {
        EconomyManager.TowerSelected += TowerSelected;
    }

    private void OnDisable()
    {
        EconomyManager.TowerSelected -= TowerSelected;
    }

    void TowerSelected(SOTower tower)
    {
        towerName.text = tower.Name;
        price.text = "Price: " + tower.Price + "$";
        speed.text = "Speed: " + tower.AttackSpeed;
        damage.text = "Damage: " + tower.Shot.GetComponent<Shot>().Damage;
        preview.sprite = tower.PreviewImage;
    }
}
