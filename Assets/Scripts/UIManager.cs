
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text correctFoodCountText;
    [SerializeField] TMP_Text incorrectFoodCountText;
    [SerializeField] TMP_Text accuracyScoreText;
    [SerializeField] TMP_Text feedbackText;
    [SerializeField] int correctFoodCount = 0;
    [SerializeField] int incorrectFoodCount = 0;
    string feedbackMessage = "Feedback for Mistakes:\n";

    [SerializeField] FoodSpawner foodSpawner;

    [SerializeField] Button resetButton;
    [SerializeField] Button startButton;
    [SerializeField] Button quitButton;

    [SerializeField] GameObject resultView;



    
    void Start()
    {
        quitButton.onClick.AddListener(() =>
        {
            resultView.SetActive(false);
            startButton.gameObject.SetActive(true);

        });

        startButton.onClick.AddListener(() => 
        {

        if (GameManager.Instance.ResetGame(foodSpawner, this))
        {    
            startButton.gameObject.SetActive(false);
        }

            
        });
        resetButton.onClick.AddListener(() => GameManager.Instance.ResetGame(foodSpawner, this));
    }

    void Update()
{
    if (GameManager.Instance.isGameActive)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.EndGame(foodSpawner, this);
            startButton.gameObject.SetActive(true);
        }
    }
}
    public void SetIncorrectFoodCount(string foodName, bool isHealthy)
    {
        incorrectFoodCount++;
        incorrectFoodCountText.text = "Incorrect Sorts: " + incorrectFoodCount.ToString();
        UpdateAccuracyUI();
        feedbackMessage += "- You put " + foodName + " in the Wrong basket, " + foodName + " is " + (isHealthy ? "healthy" : "unhealthy") + "\n";
        feedbackText.text = feedbackMessage;
      
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

        if (totalSorted > 0)
        {
            accuracy = ((float)correctFoodCount / totalSorted) * 100f;
        }

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
        resultView.SetActive(false);

    }

    public void EnableResultView()
    {
        resultView.SetActive(true);
    }

   
}
