using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spaceship : MonoBehaviour
{
    public float fuel = 100.0f;
    public float rotationAngle = 1;
    public GameObject particleObject;
    public float fuelConsumed = 0.1f;
    public GameObject explosion;

    [Space]

    public TextMeshProUGUI fuelText;
    public Image fuelBar;

    ParticleSystem flame;
    Rigidbody2D rb;
    Vector2 power;
    BoxCollider2D bc;
    Quaternion rotation = new Quaternion(0, 0, 30, 0);

    float landingSpeed;
    bool startTimer = false;
    float timer;

    void Start()
    {
        flame = particleObject.GetComponentInChildren<ParticleSystem>();
        flame.Stop();

        rb = gameObject.GetComponent<Rigidbody2D>();
        
        power = new Vector2(0, 20);
        
        landingSpeed = 10.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {            
            if (fuel > 0)
            {
                fuel -= fuelConsumed;
                flame.Play();
                rb.AddRelativeForce(power);
            }
            else
            {
                flame.Stop();
            }
        }
        else
        {
            flame.Stop();
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
        if (startTimer && timer < 3)
        {
            timer += Time.deltaTime;
        }

        if(transform.rotation.z > 10)
        {
            Debug.Log("Bruh");
        }

        fuelBar.fillAmount = fuel / 100;
        fuelText.text = ((int)fuel).ToString() + "%"; //puaj

        if(fuel <= 0)
        {
            fuelText.text = "Empty";
            fuelText.color = Color.red;
        }
    }

    public bool HasPlayerLanded()
    {
        if(timer >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.relativeVelocity.magnitude);

        if (col.relativeVelocity.magnitude >= landingSpeed)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameManager.alive = false;
        }     
    }
}
