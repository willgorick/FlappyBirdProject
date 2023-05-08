using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MetaScript : MonoBehaviour
{
    public bool gameIsOver = false;
    public int playerScore;
    public Text scoreText;
    public TMP_Text highScoreText;
    public int highScoreVal = 0;
    public GameObject gameOverScreen;

    private void Start() {
        highScoreVal = PlayerPrefs.GetInt("high_score", 0);
        highScoreText.text = "High Score: " + highScoreVal;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > highScoreVal)
        {
            highScoreText.text = "High Score: " + playerScore;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu ("Reset High Score")]
    public void resetHighScore()
    {
        PlayerPrefs.SetInt("high_score", 0);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        if (playerScore > highScoreVal)
        {
            PlayerPrefs.SetInt("high_score", playerScore);
        }
    }
}
