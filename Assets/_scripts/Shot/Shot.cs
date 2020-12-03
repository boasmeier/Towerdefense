using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private SOShot _shot;
    public int Damage { get { return _shot.Damage; } }

    private void Start()
    {
        //TODO playSound!!!
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: Handle collision
    }
}