using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinOrLose : MonoBehaviour
{
    private ScoreCount scoreCount;
    public TextMeshProUGUI resultText; // Reference to a TMP Text component to display the result

    // Start is called before the first frame update
    void Start()
    {
        // Get the ScoreCount component from the scene
        scoreCount = FindObjectOfType<ScoreCount>();
        if (scoreCount == null)
        {
            Debug.LogError("ScoreCount component not found.");
            return;
        }

        // Check the score and display the result
        int currentScore = scoreCount.GetScore();
        if (currentScore >= 5)
        {
            resultText.text = "You Win! Score: " + currentScore;
        }
        else
        {
            resultText.text = "You Lose! Score: " + currentScore;
        }
    }
}