using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Level
    {
        One, 
        Two, 
        Three
    }

    public static Level level;

    [Space]

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    [Space]

    public Spaceship ship;
    GameObject platform;

    [Space]

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    Camera cam;

    float minX;
    float maxX;
    float minY;
    float maxY;

    float camPosZ = -100;
    float offset;
    float distancePlayerPlatform;
    
    public static bool isDead;
    public static bool win;
    public static float score;

    float winBonus;
    float scoreGained;

    float gameTimer;
    
    void Start()
    {
        isDead = false;
        win = false;
        score = 0;
        winBonus = 1000.0f;
        scoreGained = 1.0f;
        offset = 0.5f;
        gameTimer = 40.0f;

        switch (level)
        {
            case Level.One:
                Instantiate(level1);
                minX = -140;
                maxX = 160;
                minY = 40;
                maxY = 120;
                break;
            case Level.Two:
                Instantiate(level2);
                minX = -140;
                maxX = 160;
                minY = 40;
                maxY = 120;
                break;
            case Level.Three:
                Instantiate(level3);
                minX = -390;
                maxX = -90;
                minY = 40;
                maxY = 120;
                break;
            default:
                break;
        }
        platform = GameObject.FindGameObjectWithTag("Landing Platform");
        cam = Camera.main;
    }

    void Update()
    {
        if (!isDead && !win)
        {
            gameTimer -= Time.deltaTime;
            score += scoreGained;

            if (ship.transform.position.y >= minY &&
               ship.transform.position.y <= maxY)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, ship.transform.position.y, camPosZ);
            }

            if (ship.transform.position.x >= minX &&
                ship.transform.position.x <= maxX)
            {
                cam.transform.position = new Vector3(ship.transform.position.x, cam.transform.position.y, camPosZ);
            }
            else if (ship.transform.position.x <= minX)
            {
                cam.transform.position = new Vector3(minX, cam.transform.position.y, camPosZ);
            }
            else if (ship.transform.position.x >= maxX)
            {
                cam.transform.position = new Vector3(maxX, cam.transform.position.y, camPosZ);
            }

            if (ship.onGround)
            {
                scoreGained = 0;
            }
            else if (ship.flying)
            {
                scoreGained = 0.5f;
            }
            else if (ship.floating)
            {
                scoreGained = 1.0f;
            }
        }

        scoreText.text = "Score: " + score.ToString("F2");
        timerText.text = "Timer: " + gameTimer.ToString("F2");

        if (ship.HasPlayerLanded())
        {
            scoreText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            if (!win)
            {
                score += winBonus;
            }

            win = true;
        }

        if(gameTimer <= 0)
        {
            ship.DestroyShip();
        }        

        if (ship)
        {
            distancePlayerPlatform = Vector2.Distance(ship.transform.position, platform.transform.position);

            if (distancePlayerPlatform < 25 &&
                camPosZ < -50)
            {
                camPosZ += offset;
            }
            else if (distancePlayerPlatform > 25 && 
                     camPosZ > -100)
                 {
                     camPosZ -= offset;
                 }
        }
    }
}