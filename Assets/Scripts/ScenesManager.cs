using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Principal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public GameManager gManager;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        switch (GameManager.level)
        {
            case GameManager.Level.One:
                GameManager.level = GameManager.Level.Two;
                break;
            case GameManager.Level.Two:
                GameManager.level = GameManager.Level.Three;
                break;
            case GameManager.Level.Three:
                GameManager.level = GameManager.Level.One;
                break;
        }
        ReplayLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
