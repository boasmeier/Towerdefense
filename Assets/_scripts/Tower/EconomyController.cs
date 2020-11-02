using UnityEngine;

public class EconomyController : MonoBehaviour
{
    //[SerializeField] private SOTower tower;
    private PlaceholderInputController _pic;
    private InputController _gic;

    private void Start()
    {
        _pic = GetComponent<PlaceholderInputController>();
        if (_pic != null)
        {
            _pic.HandleMouse += SelectPlaceholder;
        }

        _gic = GetComponent<InputController>();
        if (_gic != null)
        {
            _gic.HandleLeft += MoveArrowLeft;
            _gic.HandleRight += MoveArrowLeft;
            _gic.HandleUp += MoveArrowLeft;
            _gic.HandleDown += MoveArrowLeft;
            _gic.HandleOne += InstantiateBasic;
            _gic.HandleTwo += InstantiateFreeze;
        }
    }

    private void Update()
    {
    }

    private void SelectPlaceholder(Vector3 position)
    {
        Debug.Log(string.Format("Select Placeholder (x: {0}, z: {1})", position.x, position.z));
    }

    private void MoveArrowLeft()
    {
        Debug.Log("Move Arrow Left");
    }

    private void MoveArrowRight()
    {
        Debug.Log("Move Arrow Right");
    }

    private void MoveArrowUp()
    {
    }

    private void MoveArrowDown()
    {
    }

    private void InstantiateBasic()
    {
        Debug.Log("Instantiate Basic Tower");
    }

    private void InstantiateFreeze()
    {
        Debug.Log("Instantiate Freeze Tower");
    }
}