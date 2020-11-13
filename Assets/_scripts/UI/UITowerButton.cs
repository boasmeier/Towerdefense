using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITowerButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SOTower tower;
    [SerializeField] Text towerName;
    void Start()
    {
        towerName.text = "[" + this.tower.Id + "] " + this.tower.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
