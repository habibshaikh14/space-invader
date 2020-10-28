using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SessionScores : MonoBehaviour
{
    // Configuration Parameters
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI highScore;
    // Cached references
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        currentScore.text = "Your Score: " + gameSession.GetCurrentScore().ToString();
        gameSession.UpdateHighScore();
        highScore.text = "High Score: " + gameSession.GetHighScore().ToString();
    }
}
