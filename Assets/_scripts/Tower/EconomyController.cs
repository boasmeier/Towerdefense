using System;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;

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
            _ic.HandleOne += InstantiateBasic;
            _ic.HandleTwo += InstantiateFreeze;
        }
        this.Rotate(0);
    }

    private void SelectPlaceholder(Vector3 position)
    {
        Debug.Log(string.Format("Select Placeholder (x: {0}, z: {1})", position.x, position.z));
        position.y = 1;
        TowerController.position = position;
        ArrowController.position = position;
        this._isPlaceable = true;
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

    private void CreateTower(string name, GameObject tower)
    {
        if (!this._isPlaceable && tower != null) return;
        TowerController.tower = tower;
        GameObject towerClone = TowerController.Build();
        //TODO: GetComponenent below maybe not state of the art??? Is there a better way?
        int price = towerClone.GetComponent<ShootController>().Tower.Price;
        if (lM.CheckIfEnoughMoney(price))
        {
            HandleTowerBuyOrSell(-price);
            Debug.Log("Instantiate Tower " + name);
        }
        else
        {
            Destroy(towerClone);
            Debug.Log("Not enough money to buy a tower!");
        }
        this._isPlaceable = false;
    }

    private void InstantiateBasic()
    {
        this.CreateTower("Basic", this.towers[0]);
    }

    private void InstantiateFreeze()
    {
        this.CreateTower("Freeze", null);
    }

    private void Rotate(int angle)
    {
        if (!this._isPlaceable) return;
        ArrowController.rotation = angle * -1;
        TowerController.rotation = angle;
    }
}