using System;

public interface ITowerSelector
{
    event Action<int> HandleTowerSelected;
}
