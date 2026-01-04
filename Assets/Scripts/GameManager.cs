
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public FoodSpawner foodSpawner;
    public bool isGameActive = false;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
         
            Destroy(gameObject);
        }
        else
        {
          
            Instance = this;

           
            DontDestroyOnLoad(gameObject);
        }
    }

    
public void EndGame(FoodSpawner foodSpawner=null, UIManager uiManager=null)
    {
        isGameActive = false;
        if (foodSpawner != null)
        {
            foodSpawner.DeleteAllFood();
        }
        if (uiManager != null)
        {
            uiManager.ResetUI();
        }
    }
    public bool ResetGame(FoodSpawner foodSpawner=null, UIManager uiManager=null)
    {
        this.uiManager=uiManager;
        this.foodSpawner=foodSpawner;

        if (!isGameActive)
        {
            isGameActive = true;
        } 
        else {
            return false;
        }

        if (foodSpawner != null)
        {
            foodSpawner.DeleteAllFood();
            foodSpawner.SpawnAllFood();
        }

     
        if (uiManager != null)
        {
            uiManager.ResetUI();
        }

        return true;
    }

   
}



