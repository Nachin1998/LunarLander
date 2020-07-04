using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool alive;
    bool pauseMenuActive;
    void Start()
    {
        pauseMenuActive = false;
    }

    private void FixedUpdate()
    {
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuActive)
            {
                pauseMenuActive = true;
            }
            else
            {
                pauseMenuActive = false;
            }
        }

        if (pauseMenuActive)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }


    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pauseMenuActive = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        pauseMenuActive = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
