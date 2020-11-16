using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private List<TowerEntry> towers;

    public static event Action<int> HandleTowerBuyOrSell = delegate { };
    public static event Action<string> DisplayNotEnoughMoney = delegate { };

    public static event Action<SOTower> TowerSelected = delegate { };
    public static event Action<int> DirectionSelected = delegate { };

    private bool _isPlaceable;
    private LevelManager lM;
    private IList<IArrowsInputController> _aIcs;
    private IList<ITowerSelector> _aTss;

    private void OnEnable()
    {
        lM = FindObjectOfType<LevelManager>();
        PlaceholderInputController.HandleMouse += SelectPlaceholder;

        _aIcs = FindObjectsOfType<MonoBehaviour>().OfType<IArrowsInputController>().ToList();

        foreach (IArrowsInputController aic in _aIcs)
        {
            aic.HandleLeft += MoveArrowLeft;
            aic.HandleRight += MoveArrowRight;
            aic.HandleUp += MoveArrowUp;
            aic.HandleDown += MoveArrowDown;
        }

        _aTss = FindObjectsOfType<MonoBehaviour>().OfType<ITowerSelector>().ToList();

        foreach (ITowerSelector ts in _aTss)
        {
            ts.HandleTowerSelected += BuildTower;
        }

        this.Rotate(0);
    }

    private void OnDisable()
    {
        foreach (IArrowsInputController aic in _aIcs)
        {
            aic.HandleLeft -= MoveArrowLeft;
            aic.HandleRight -= MoveArrowRight;
            aic.HandleUp -= MoveArrowUp;
            aic.HandleDown -= MoveArrowDown;
        }

        foreach (ITowerSelector ts in _aTss)
        {
            ts.HandleTowerSelected -= BuildTower;
        }
    }

    private void BuildTower(int id)
    {
        if (!this._isPlaceable) return;
        TowerEntry entry = this.getTowerEntry(id);
        TowerSelected(entry.details);
        TowerController.Build(entry.geometry);
        this.HandleFinance(entry);
        this._isPlaceable = false;
    }

    private TowerEntry getTowerEntry(int id)
    {
        return this.towers
            .Where(t => t.details.Id == id)
            .FirstOrDefault();
    }

    private void HandleFinance(TowerEntry entry)
    {
        if (lM.CheckIfEnoughMoney(entry.details.Price))
        {
            HandleTowerBuyOrSell(-entry.details.Price);
        }
        else
        {
            //Debug.Log("Not enough money to buy a tower!");
            DisplayNotEnoughMoney("Not enough money to buy a tower!");
        }
    }

    private void MoveArrowLeft()
    {
        this.Rotate(270);
    }

    private void MoveArrowRight()
    {
        this.Rotate(90);
    }

    private void MoveArrowUp()
    {
        this.Rotate(0);
    }

    private void MoveArrowDown()
    {
        this.Rotate(180);
    }

    private void Rotate(int angle)
    {
        if (!this._isPlaceable) return;
        DirectionSelected(angle);
        ArrowController.rotation = angle * -1;
        TowerController.rotation = angle;
    }

    private void SelectPlaceholder(Vector3 position)
    {
        Debug.Log(string.Format("Select Placeholder (x: {0}, z: {1})", position.x, position.z));
        position.y = 1;
        TowerController.position = position;
        ArrowController.position = position;
        this._isPlaceable = true;
    }
}