using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;

    public TextMeshProUGUI gameState;
    public TextMeshProUGUI score;
    public TextMeshProUGUI nextLevelButton;

    private void Update()
    {
        if (GameManager.win || GameManager.isDead)
        {
            gameOverMenu.SetActive(true);
        }

        if (GameManager.win)
        {            
            gameState.text = "You Win!";
            gameState.color = Color.green;
        }
        else if (GameManager.isDead)
        {
            gameState.text = "You Lost";
            gameState.color = Color.red;
        }

        if(GameManager.level == GameManager.Level.Three)
        {
            nextLevelButton.text = "Back to First Level";
        }
        else
        {
            nextLevelButton.text = "Next Level";
        }

        score.text = "Score: " + GameManager.score.ToString();
    }
}
