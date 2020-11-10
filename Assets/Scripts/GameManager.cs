using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public TextMeshProUGUI healthText;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
        health = 100;
        UpdateHealth(0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
