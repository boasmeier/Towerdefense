using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private List<TowerEntry> towers;

    public static event Action<int> HandleTowerBuyOrSell = delegate { };

    private InputController _ic;
    private bool _isPlaceable;
    private LevelManager lM;

    private void Start()
    {
        lM = FindObjectOfType<LevelManager>();
        PlaceholderInputController.HandleMouse += SelectPlaceholder;

        _ic = GetComponent<InputController>();
        if (_ic != null)
        {
            _ic.HandleLeft += MoveArrowLeft;
            _ic.HandleRight += MoveArrowRight;
            _ic.HandleUp += MoveArrowUp;
            _ic.HandleDown += MoveArrowDown;
            _ic.HandleNumber += BuildTower;
        }
        this.Rotate(0);
    }

    private void BuildTower(int id)
    {
        if (!this._isPlaceable) return;
        TowerEntry entry = this.getTowerEntry(id);
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
            //TODO: Display not enough money information.
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