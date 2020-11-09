using System;
using UnityEngine;

//This class should be implemented, if a healthController is used
public interface IHealthController
{
    //publishes the current remaining percentage of health 
    event Action<int> HandlePercentageHealthChange;
    //publishes the absolute remaining health
    event Action<int> HandleHealthChange;
    //publishes if health is zero
    event Action HandleDeath;
}
