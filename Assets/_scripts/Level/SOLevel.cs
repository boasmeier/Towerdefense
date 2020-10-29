using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class SOLevel : ScriptableObject

{
    [SerializeField] private int startMoney;
    [SerializeField] private List<Vector3> route;
    [SerializeField] private List<Wave> waves;
    
    public int StartMoney { get { return this.startMoney; } }
    public int TotalWaves { get { return this.totalWaves; } }
    public List<Vector3> Route { get { return this.route; } }
    public List<Wave> Waves { get { return this.waves; } }
}
