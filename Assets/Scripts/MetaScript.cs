using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.InputSystem;

public class MetaScript : MonoBehaviour
{
    public bool gameIsOver = false;
    public int playerScore;
    public Text scoreText;
    public TMP_Text highScoreText;
    public int highScoreVal = 0;
    public GameObject gameOverScreen;
    public string saveFileLocation;

    [SerializeField]
    private InputActionReference escape;

    private void OnEnable() 
    {
        escape.action.performed += Quit;
    }

    private void OnDisable()
    {
        escape.action.performed -= Quit;   
    }

    public void Quit(InputAction.CallbackContext obj)
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
    }

    private void Start() {
        saveFileLocation = Application.persistentDataPath + "/flappy_save.dat";
        highScoreVal = loadGame();
        highScoreText.text = "High Score: " + highScoreVal;
    }

    private void Update() {
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > highScoreVal)
        {
            highScoreVal = playerScore;
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
        saveGame();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        saveGame(highScoreVal);
    }

    public void saveGame(int newHighScore=0)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(saveFileLocation);
        SaveData data = new SaveData();
        data.highScore = newHighScore;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved");
    }

    public int loadGame()
    {
        int currentHighScore = 0;
        Debug.Log("looking for save file at: " + saveFileLocation);
        if (File.Exists(saveFileLocation))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(saveFileLocation, FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            currentHighScore = data.highScore > 0 ? data.highScore : 0;
            Debug.Log("Accessed save file and found high score of: " + currentHighScore);
        }
        else
        {
            Debug.Log("No high score saved yet, setting to 0");
        }
        return currentHighScore;
    }
}

[SerializableAttribute]
class SaveData
{
    public int highScore;
}
