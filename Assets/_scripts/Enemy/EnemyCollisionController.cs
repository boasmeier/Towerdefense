using System;
using UnityEngine;

public class EnemyCollisionController : MonoBehaviour
{
    LayerMask shotLayer;
    public event Action<int> HandleCollision = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        shotLayer  = LayerMask.NameToLayer("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        Debug.Log(shotLayer);
        if(collision.gameObject.layer == shotLayer)
        {
            Debug.Log("Collided");
            HandleCollision(collision.gameObject.GetComponent<Shot>().Damage);
            Destroy(collision.gameObject);
        }
    }
}
