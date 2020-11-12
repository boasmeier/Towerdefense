using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerSelector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SOTower tower;
    [SerializeField] Text towerName;
    [SerializeField] Text price;
    [SerializeField] Button buy;
    void Start()
    {
        towerName.text = this.tower.Name;
        price.text = this.tower.Price + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
