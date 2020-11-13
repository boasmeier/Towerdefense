using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private List<TowerEntry> towers;

    public static event Action<int> HandleTowerBuyOrSell = delegate { };
    public static event Action<string> DisplayNotEnoughMoney = delegate { };
    public static event Action<int> TowerSelected = delegate { };
    public static event Action<int> DirectionSelected = delegate { };

    private InputController _ic;
    private bool _isPlaceable;
    private LevelManager lM;
    private IList<IArrowsInputController> _aIcs;

    private void Start()
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

        _ic = GetComponent<InputController>();
        if (_ic != null)
        {
            _ic.HandleNumber += BuildTower;
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
            //Debug.Log("Not enough money to buy a tower!");
            DisplayNotEnoughMoney("Not enough money to buy a tower!");
        }
    }

    private void MoveArrowLeft()
    {
        Debug.Log("MoveArrowLeft");
        int degree = 270;
        DirectionSelected(degree);
        this.Rotate(degree);
    }

    private void MoveArrowRight()
    {
        Debug.Log("MoveArrowRight");

        int degree = 90;
        DirectionSelected(degree);
        this.Rotate(degree);
    }

    private void MoveArrowUp()
    {
        Debug.Log("MoveArrowUp");

        int degree = 0;
        DirectionSelected(degree);
        this.Rotate(degree);
    }

    private void MoveArrowDown()
    {
        Debug.Log("MoveArrowDown");

        int degree = 180;
        DirectionSelected(degree);
        this.Rotate(degree);
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