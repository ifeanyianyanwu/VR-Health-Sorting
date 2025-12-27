using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text correctFoodCountText;
    [SerializeField] TMP_Text incorrectFoodCountText;
    [SerializeField] TMP_Text accuracyScoreText;
    [SerializeField] TMP_Text feedbackText;
    int correctFoodCount = 0;
    int incorrectFoodCount = 0;
    string feedbackMessage = "Feedback for Mistakes:\n";

    [SerializeField] Button resetButton;


    
    void Start()
    {
        resetButton.onClick.AddListener(() => GameManager.Instance.ResetGame());
    }
    public void SetIncorrectFoodCount(string foodName, bool isHealthy)
    {
        incorrectFoodCount++;
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
        UpdateAccuracyUI();
        feedbackMessage += "- You put " + foodName + " in the Wrong basket, " + foodName + " is " + (isHealthy ? "healthy" : "unhealthy") + "\n";
        feedbackText.text = feedbackMessage;
        // You put Orange in the Wrong basket, Orange is healthy
        // You put Candy in the Wrong basket, Candy is unhealthy
    }
    public void SetCorrectFoodCount()
    {
        correctFoodCount++;
        correctFoodCountText.text = "Correct Sorts: " + correctFoodCount.ToString();
        UpdateAccuracyUI();

    }

  

private void UpdateAccuracyUI()
    {
        int totalSorted = correctFoodCount + incorrectFoodCount;
        float accuracy = 0f;

        // Prevent "Division by Zero" errors if nothing has been sorted yet
        if (totalSorted > 0)
        {
            // (float) cast is required to get decimal results
            accuracy = ((float)correctFoodCount / totalSorted) * 100f;
        }

        // Update the text. "F0" formats it to 0 decimal places (e.g., "80%")
        if (accuracyScoreText != null)
        {
            accuracyScoreText.text = "Accuracy Score: " + accuracy.ToString("F0") + "%";
        }
    }
    public void ResetUI()
    {
        correctFoodCount = 0;
        incorrectFoodCount = 0;
        correctFoodCountText.text = "Correct Sorts: " + correctFoodCount.ToString();
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
        feedbackMessage = "Feedback for Mistakes:\n";
        feedbackText.text = feedbackMessage;
        if (accuracyScoreText != null)
        {
            accuracyScoreText.text = "Accuracy Score: 0%";
        }
    }

    public int GetCorrectFoodCount() => correctFoodCount;
    public int GetIncorrectFoodCount() => incorrectFoodCount;
}
