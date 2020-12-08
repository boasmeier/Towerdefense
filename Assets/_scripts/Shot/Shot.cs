using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private SOShot _shot;
    public int Damage { get { return _shot.Damage; } }

    private LayerMask enemyLayer;
    private LayerMask towerLayer;

    private void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        towerLayer = LayerMask.NameToLayer("Tower");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(IsEnemy(collision.gameObject) || IsOwnTower(collision.gameObject))
        {
            return;
        }
        
        Destroy(gameObject);
    }

    private bool IsOwnTower(GameObject collisionObject)
    {
        if (collisionObject.layer != towerLayer.value)
        {
            return false;
        }

        return collisionObject.transform.parent.gameObject == gameObject.transform.parent.gameObject;
    }

    private bool IsEnemy(GameObject collisionObject)
    {
        return collisionObject.layer == enemyLayer.value;
    }
}