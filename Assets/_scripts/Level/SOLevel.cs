using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class SOLevel : ScriptableObject

{
    [SerializeField] private int startMoney;
    [SerializeField] private int totalWaves;
    [SerializeField] private List<Vector3> route;
    
    public int StartMoney { get { return this.startMoney; } }
    public int TotalWaves { get { return this.totalWaves; } }
    public List<Vector3> Route { get { return this.route; } }

}
