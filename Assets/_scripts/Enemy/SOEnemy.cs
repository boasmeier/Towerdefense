using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class SOEnemy : ScriptableObject
{
    [SerializeField] private int health;
    [SerializeField] private int value;
    [SerializeField] private int speed;
    public int Speed
    {
        get { return speed; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
