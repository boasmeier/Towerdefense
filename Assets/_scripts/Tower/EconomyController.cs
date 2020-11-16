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

    private bool _placeholderSelected;
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
        if (!this.CanBuild(id)) return;
        TowerEntry entry = this.GetTowerEntry(id);
        HandleTowerBuyOrSell(-entry.details.Price);
        TowerSelected(entry.details);
        TowerController.Build(entry.geometry);
        this.HandleFinance(entry);
        this._placeholderSelected = false;
    }

    private bool CanBuild(int id)
    {
        if (!this._placeholderSelected) return false;
        TowerEntry entry = this.GetTowerEntry(id);

        if (entry == null)
        {
            Debug.Log(string.Format("Tower with id: {0} does not exists.", id));
            return false;
        }

        if (!lM.CheckIfEnoughMoney(entry.details.Price))
        {
            DisplayNotEnoughMoney("Not enough money to buy a tower!");
            return false;
        }
        return true;
    }

    private TowerEntry GetTowerEntry(int id)
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
        if (!this._placeholderSelected) return;
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
        this._placeholderSelected = true;
    }
}