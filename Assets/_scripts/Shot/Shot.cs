using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private SOShot _shot;
    public int Damage { get { return _shot.Damage; } }

    private LayerMask enemyLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Shot");

    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.layer != enemyLayer.value)
        {
            Destroy(gameObject);
        }*/

    }
}