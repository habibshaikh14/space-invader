using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // Cached references
    TextMeshProUGUI healthText;
    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        healthText.text = gameSession.GetPlayerHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = gameSession.GetPlayerHealth().ToString();
    }
}
