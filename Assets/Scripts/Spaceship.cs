using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spaceship : MonoBehaviour
{
    public float fuel = 100;
    public float rotationAngle = 1;
    public GameObject particleObject;
    public float fuelConsumed = 0.1f;
    public GameObject explosion;
    public AudioSource thrustSound;

    [Space]

    public TextMeshProUGUI fuelText;
    public Image fuelBar;

    ParticleSystem flame;
    Rigidbody2D rb;
    Vector2 power;
    int maxTimer;

    float landingSpeed;
    bool startTimer;
    public bool flying;
    public bool floating;
    public bool onGround;
    float timer;

    void Start()
    {
        flame = particleObject.GetComponentInChildren<ParticleSystem>();
        flame.Stop();

        rb = gameObject.GetComponent<Rigidbody2D>();
        
        power = new Vector2(0, 20);
        
        maxTimer = 2;

        landingSpeed = 10.0f;

        startTimer = false;

        flying = false;

        timer = 0;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {            
            if (fuel > 0)
            {
                flying = true;
                fuel -= fuelConsumed;
                flame.Play();
                rb.AddRelativeForce(power);
                if (!thrustSound.isPlaying)
                {
                    thrustSound.Play();
                }
            }
            else
            {
                flame.Stop();
                thrustSound.Stop();
            }
        }
        else
        {
            flying = false;
            flame.Stop();
            thrustSound.Stop();
            if (!onGround)
            {
                floating = true;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, rotationAngle);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -rotationAngle);
        }
    }
    void Update()
    {
        fuelBar.fillAmount = fuel / 100;
        fuelText.text = ((int)fuel).ToString() + "%"; //puaj

        if (!startTimer)
        {
            timer = 0;
        }
        else if (startTimer && timer < 2)
        {
            timer += Time.deltaTime;
        }

        if(fuel <= 0)
        {
            fuelText.text = "Empty";
            fuelText.color = Color.red;
        }
    }

    public bool HasPlayerLanded()
    {
        return (timer >= maxTimer);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude >= landingSpeed)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.isDead = true;
        }
        else if (col.relativeVelocity.magnitude <= landingSpeed &&
                 col.gameObject.tag == "Landing Platform")
             {
                 startTimer = true;
             }
        else if (col.relativeVelocity.magnitude <= landingSpeed &&
                 col.gameObject.tag == "Rock")
             {
                 onGround = true;
             }
    }

    public void DestroyShip()
    {
        if (gameObject)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.isDead = true;
        }
    }
}
