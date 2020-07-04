using UnityEngine;

public class SideCollisions : MonoBehaviour
{
    public GameObject ship;
    public GameObject explosion;
    void OnCollisionEnter2D(Collision2D col)
    {

        Instantiate(explosion,ship.transform.position, Quaternion.identity);
        Destroy(ship);
        GameManager.alive = false;
    }
}