using System;
using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;

    public static event Action<int> HandleTowerBuyOrSell = delegate { };

    private InputController _ic;
    private Vector3 _spawnPosition;
    private bool _isPlaceable;
    private Quaternion _rotation;
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
        this.SetRotation(0);
    }

    private void Update()
    {
    }

    private void SelectPlaceholder(Vector3 position)
    {
        Debug.Log(string.Format("Select Placeholder (x: {0}, z: {1})", position.x, position.z));
        position.y = 1;
        this._spawnPosition = position;
        this._isPlaceable = true;
    }

    private void MoveArrowLeft()
    {
        this.SetRotation(270);
    }

    private void MoveArrowRight()
    {
        this.SetRotation(90);
    }

    private void MoveArrowUp()
    {
        this.SetRotation(0);
    }

    private void MoveArrowDown()
    {
        this.SetRotation(180);
    }

    private void CreateTower(string name, GameObject tower)
    {
        if (!this._isPlaceable && tower != null) return;
        GameObject towerClone = Instantiate(tower, this._spawnPosition, this._rotation);
        //TODO: GetComponenent below maybe not state of the art??? Is there a better way?
        int price = towerClone.GetComponent<ShootController>().Tower.Price;
        if(lM.CheckIfEnoughMoney(price)) {
            HandleTowerBuyOrSell(-price);
            Debug.Log("Instantiate Tower " + name);
        } else {
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

    private void SetRotation(int angle)
    {
        if (!this._isPlaceable) return;
        Debug.Log("Set angle: " + angle);
        this._rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}