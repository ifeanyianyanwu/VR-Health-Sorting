using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text correctFoodCountText;
    [SerializeField] TMP_Text incorrectFoodCountText;
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
    }
    public void SetCorrectFoodCount()
    {
        correctFoodCount++;
        correctFoodCountText.text = "Correct Sorts: " + correctFoodCount.ToString();
    }

    public void ResetCounts()
    {
        correctFoodCount = 0;
        incorrectFoodCount = 0;
        correctFoodCountText.text = "Correct Sorts: " + correctFoodCount.ToString();
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
    }

    public int GetCorrectFoodCount()
    {
        return correctFoodCount;
    }

    public int GetIncorrectFoodCount()
    {
        return incorrectFoodCount;
    }
}
