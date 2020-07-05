using UnityEngine;

public class SideCollisions : MonoBehaviour
{
    public Spaceship ship;
    public GameObject explosion;
    void OnCollisionEnter2D(Collision2D col)
    {
        ship.DestroyShip();
    }
}