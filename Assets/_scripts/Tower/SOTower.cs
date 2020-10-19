using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Tower")]
public class SOTower : ScriptableObject
{
    [SerializeField] private int price;
    [SerializeField] private int attackSpeed;
    [SerializeField] private GameObject shot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
