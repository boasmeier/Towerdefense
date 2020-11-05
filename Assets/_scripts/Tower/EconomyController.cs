using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] private GameObject[] towers;

    private InputController _ic;
    private Vector3 _spawnPosition;
    private bool _isPlaceable;
    private Quaternion _rotation;

    private void Start()
    {
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

    private void Instantiate(string name, GameObject tower)
    {
        if (!this._isPlaceable && tower != null) return;
        Debug.Log("Instantiate Tower " + name);
        Instantiate(tower, this._spawnPosition, this._rotation);
        this._isPlaceable = false;
    }

        private void InstantiateBasic()
    {
        this.Instantiate("Basic", this.towers[0]);
    }

    private void InstantiateFreeze()
    {
        this.Instantiate("Freeze", null);
    }

    private void SetRotation(int angle)
    {
        if (!this._isPlaceable) return;
        Debug.Log("Set angle: " + angle);
        this._rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}