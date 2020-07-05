using UnityEngine;

public class SideCollisions : MonoBehaviour
{
    public Spaceship ship;
    void OnCollisionEnter2D(Collision2D col)
    {
        ship.DestroyShip();
    }
}