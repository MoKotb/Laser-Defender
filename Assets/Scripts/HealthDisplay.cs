using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private Player player;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        scoreText.text = player.GetHealth().ToString();
    }
}
