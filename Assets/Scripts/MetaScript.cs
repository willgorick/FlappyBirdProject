using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MetaScript : MonoBehaviour
{
    public bool gameIsOver = false;
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

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
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
