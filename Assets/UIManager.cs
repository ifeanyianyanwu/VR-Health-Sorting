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
    int correctFoodCount = 0;
    int incorrectFoodCount = 0;
    
    void Start()
    {
        ResetCounts();
    }
    public void SetIncorrectFoodCount()
    {
        incorrectFoodCount++;
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
        UpdateAccuracyUI();
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
    public void ResetCounts()
    {
        correctFoodCount = 0;
        incorrectFoodCount = 0;
               correctFoodCountText.text = "Correct Sorts: " + correctFoodCount.ToString();
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
        
        if (accuracyScoreText != null)
        {
            accuracyScoreText.text = "Accuracy Score: 0%";
        }
    }

    public int GetCorrectFoodCount() => correctFoodCount;
    public int GetIncorrectFoodCount() => incorrectFoodCount;
}
