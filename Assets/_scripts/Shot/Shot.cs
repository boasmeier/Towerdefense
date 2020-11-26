using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private SOShot shot;
    public int Damage { get { return this.shot.Damage; } }

    // Start is called before the first frame update
    private void Start()
    {
        //TODO playSound!!!
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //TODO: Handle collision
    }
}