using System;
using UnityEngine;

//This class should be implemented, if a healthController is used
public interface IHealthController
{
    //publishes the current remaining percentage of health 0.0f-1.0f
    event Action<float> HandlePercentageHealthChange;
    //publishes the absolute remaining health
    event Action<int> HandleHealthChange;
    //publishes if health is zero
    event Action HandleDeath;
}
