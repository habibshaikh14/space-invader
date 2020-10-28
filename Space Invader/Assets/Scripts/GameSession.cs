using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    // State Variables
    private int highScore = 0;
    private int currentScore = 0;
    private int playerHealth = 0;
    private void Awake()
    {
        SetupSingleton();
    }

    private void SetupSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void UpdateHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void IncrementCurrentScore(int incrementValue)
    {
        currentScore += incrementValue;
    }

    public void ResetCurrentScore()
    {
        currentScore = 0;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void SetPlayerHealth(int playerHealth)
    {
        this.playerHealth = playerHealth;
    }
}
