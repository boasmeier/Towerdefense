using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    [SerializeField] private List<TowerEntry> towers;

    public static event Action<int> HandleTowerBuyOrSell = delegate { };
    public static event Action<string> DisplayNotEnoughMoney = delegate { };

    public static event Action<SOTower> TowerSelected = delegate { };
    public static event Action<int> DirectionSelected = delegate { };

    private bool _placeholderSelected;
    private LevelManager levelManager;

    private TowerEntry selected;
    
    private IList<IArrowsInputController> arrowInputController;
    private IList<ITowerSelector> towerSelector;
    private IList<ITowerBuyController> towerBuyController;

    private void Awake() {
        levelManager = FindObjectOfType<LevelManager>();
        arrowInputController = FindObjectsOfType<MonoBehaviour>().OfType<IArrowsInputController>().ToList();
        towerSelector = FindObjectsOfType<MonoBehaviour>().OfType<ITowerSelector>().ToList();
        towerBuyController = FindObjectsOfType<MonoBehaviour>().OfType<ITowerBuyController>().ToList();
    }

    private void OnEnable()
    {
        PlaceholderInputController.HandleMouse += SelectPlaceholder;

        foreach (IArrowsInputController aic in arrowInputController)
        {
            aic.HandleLeft += MoveArrowLeft;
            aic.HandleRight += MoveArrowRight;
            aic.HandleUp += MoveArrowUp;
            aic.HandleDown += MoveArrowDown;
        }

        foreach (ITowerSelector ts in towerSelector)
        {
            ts.HandleTowerSelected += SelectTower;
        }

        foreach (ITowerBuyController tbc in towerBuyController)
        {
            tbc.HandleTowerBuy += BuildTower;
        }
    }

    private void Start()
    {
        Rotate(0);
        SelectTower(1);
    }

    private void OnDisable()
    {
        foreach (IArrowsInputController aic in arrowInputController)
        {
            aic.HandleLeft -= MoveArrowLeft;
            aic.HandleRight -= MoveArrowRight;
            aic.HandleUp -= MoveArrowUp;
            aic.HandleDown -= MoveArrowDown;
        }

        foreach (ITowerSelector ts in towerSelector)
        {
            ts.HandleTowerSelected -= SelectTower;
        }

        foreach (ITowerBuyController tbc in towerBuyController)
        {
            tbc.HandleTowerBuy -= BuildTower;
        }
    }

    private void SelectTower(int id)
    {
        TowerEntry entry = GetTowerEntry(id);
        TowerSelected(entry.details);
        selected = entry;
    }

    private void BuildTower()
    {
        if (!CanBuild()) return;
        TowerController.Build(selected.geometry);
        HandleFinance(selected);
        _placeholderSelected = false;
    }

    private bool CanBuild()
    {
        if (!_placeholderSelected) return false;

        if (selected == null)
        {
            Debug.Log(string.Format("No Tower selected"));
            return false;
        }

        if (!levelManager.CheckIfEnoughMoney(selected.details.Price))
        {
            DisplayNotEnoughMoney("Not enough money to buy a tower!");
            return false;
        }
        return true;
    }

    private TowerEntry GetTowerEntry(int id)
    {
        return towers
            .Where(t => t.details.Id == id)
            .FirstOrDefault();
    }

    private void HandleFinance(TowerEntry entry)
    {
        if (levelManager.CheckIfEnoughMoney(entry.details.Price))
        {
            HandleTowerBuyOrSell(-entry.details.Price);
        }
        else
        {
            DisplayNotEnoughMoney("Not enough money to buy a tower!");
        }
    }

    private void MoveArrowLeft()
    {
        Rotate(270);
    }

    private void MoveArrowRight()
    {
        Rotate(90);
    }

    private void MoveArrowUp()
    {
        Rotate(0);
    }

    private void MoveArrowDown()
    {
        Rotate(180);
    }

    private void Rotate(int angle)
    {
        if (!_placeholderSelected) return;
        DirectionSelected(angle);
        ArrowController.rotation = angle * -1;
        TowerController.rotation = angle;
    }

    private void SelectPlaceholder(Vector3 position)
    {
        position.y = 1;
        TowerController.position = position;
        ArrowController.position = position;
        _placeholderSelected = true;
    }
}
