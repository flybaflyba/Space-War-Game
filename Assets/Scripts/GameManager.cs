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
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    private SpawnManager spawnManager;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score < 0 || health <= 0)
        {
            GameOver();
        }
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
