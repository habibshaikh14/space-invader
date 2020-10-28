using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScores : MonoBehaviour
{
    // Cached references
    TextMeshProUGUI scoreText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        scoreText.text = gameSession.GetCurrentScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.GetCurrentScore().ToString();
    }
}
