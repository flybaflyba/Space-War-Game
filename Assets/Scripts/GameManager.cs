using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI healthText;
    public int health;
    public TextMeshProUGUI timeText;
    private float time = 5;
    public TextMeshProUGUI enemyText;
    public TextMeshProUGUI hightscoreText;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    private SpawnManager spawnManager;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        // PlayerPrefs.SetInt("savedScore", 0);
        // PlayerPrefs.SetInt("savedHealth", 100);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(time);

        if (isGameActive)
        {
            if (score < 0 || health <= 0)
            {
                GameOver();
            }

            if (isGameActive)
            {
                if (time > 0)
                {
                    time = time - Time.deltaTime;
                    timeText.text = "Time: " + Mathf.CeilToInt(time % 60);
                }
                else
                {
                    GameOver();
                }
            }
        }
        int numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyText.text = "Enemies: " + numOfEnemies;

        int highScore = PlayerPrefs.GetInt("highScore");
        hightscoreText.text = "Hightscore: " + highScore;

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void UpdateHealth(int healthToAdd)
    {
        health += healthToAdd;
        healthText.text = "Health: " +  health;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        // PlayerPrefs.SetInt("savedScore", score);
        // PlayerPrefs.SetInt("savedHealth", health);
        int oldHighScore = PlayerPrefs.GetInt("highScore");
        // Debug.Log(oldHighScore);
        if (score > oldHighScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        score = 0;
        UpdateScore(0);
        health = 100;
        UpdateHealth(0);
        isGameActive = true;
        spawnManager.StartSpawn(difficulty);
        titleScreen.gameObject.SetActive(false);
    }
}
