using System;

public interface ITowerSelector
{
    event Action<int> HandleTowerSelected;
    event Action<int> HandleDirectionSelected;
}
