using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Level")]
public class SOLevel : ScriptableObject

{
    [SerializeField] private int startMoney;
    [SerializeField] private int totalWaves;
    [SerializeField] private List<Vector3> route;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
