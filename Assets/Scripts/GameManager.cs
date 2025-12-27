using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static reference to the single instance of the class
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public FoodSpawner foodSpawner;

    private void Awake()
    {
        // 1. Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // If another instance exists, destroy this one
            // to enforce the singleton constraint.
            Destroy(gameObject);
        }
        else
        {
            // 2. If no instance exists, make this the single instance
            Instance = this;

            // 3. Optional: Prevent this object from being destroyed when loading new scenes.
            // This is standard for a GameManager.
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
       
        if (foodSpawner != null)
        {
            foodSpawner.DeleteAllFood();
            foodSpawner.SpawnAllFood();
        }

     
        if (uiManager != null)
        {
            uiManager.ResetUI();
        }
    }

    // Example of a function you can call from any other script:
    /*
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application quitting...");
    }
    */
}