using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    public GameObject statsMenu;
    public GameObject statsButton;

    public TextMeshProUGUI hVelocity;
    public TextMeshProUGUI vVelocity;
    public TextMeshProUGUI altitude;

    [Space]

    public Spaceship ship;

    Rigidbody2D rb;
    
    void Start()
    {
        rb = ship.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (ship)
        {
            hVelocity.text = "Horizontal velocity: " + rb.velocity.x.ToString("F2");
            vVelocity.text = "Vertical velocity: " + rb.velocity.y.ToString("F2");
            altitude.text = "Altitude: " + ship.transform.position.y.ToString("F2");
        }
        else
        {
            statsMenu.gameObject.SetActive(false);
            statsButton.gameObject.SetActive(false);
        }
    }
}
