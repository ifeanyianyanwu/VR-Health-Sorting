using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Static reference to the single instance of the class
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public FoodSpawner foodSpawner;
    public bool isGameActive = false;

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

    // Example of a function you can call from any other script:
    /*
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application quitting...");
    }
    */
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit; // 1. Added for XR components

// public class GameManager : MonoBehaviour
// {
//     // Static reference to the single instance of the class
//     public static GameManager Instance { get; private set; }
//     public UIManager uiManager;
//     public FoodSpawner foodSpawner;
//     public bool isGameActive = false;
//     public GameObject playerXRRig; // Drag your 'XR Origin' or 'XR Rig' here
//     public ActionBasedContinuousMoveProvider moveProvider; // Drag the object with the Move Provider here

//     private void Awake()
//     {
//         // 1. Check if an instance already exists
//         if (Instance != null && Instance != this)
//         {
//             // If another instance exists, destroy this one
//             // to enforce the singleton constraint.
//             Destroy(gameObject);
//         }
//         else
//         {
//             // 2. If no instance exists, make this the single instance
//             Instance = this;

//             // 3. Optional: Prevent this object from being destroyed when loading new scenes.
//             // This is standard for a GameManager.
//             DontDestroyOnLoad(gameObject);
//         }
//     }

//     // Updated ResetGame to accept the Stand Position
//     public bool ResetGame(FoodSpawner foodSpawner = null, UIManager uiManager = null, Transform standPosition = null)
//     {
//         this.uiManager = uiManager;
//         this.foodSpawner = foodSpawner;

//         if (!isGameActive)
//         {
//             isGameActive = true;
//         }
//         else
//         {
//             return false;
//         }

//         // // --- New Logic: Teleport and Lock Player ---
//         // if (playerXRRig != null && standPosition != null)
//         // {
//         //     // 1. Teleport player to the table
//         //     playerXRRig.transform.position = standPosition.position;
//         //     // Align rotation so they face the table (optional but recommended)
//         //     playerXRRig.transform.rotation = standPosition.rotation;
//         // }

//         // if (moveProvider != null)
//         // {
//         //     // 2. Disable movement so they stay at the table
//         //     moveProvider.enabled = false;
//         // }
//         // // -------------------------------------------

//         if (foodSpawner != null)
//         {
//             foodSpawner.DeleteAllFood();
//             foodSpawner.SpawnAllFood();
//         }

//         if (uiManager != null)
//         {
//             uiManager.ResetUI();
//         }

//         return true;
//     }

//     // Call this function when the user clicks "Quit" on the results UI
//     public void EndGameSession()
//     {
//         // isGameActive = false;

//         // // Re-enable movement so the player can walk away
//         // if (moveProvider != null)
//         // {
//         //     moveProvider.enabled = true;
//         // }
        
//         // // Optional: clear food if you want the table empty when they quit
//         // if (foodSpawner != null)
//         // {
//         //     foodSpawner.DeleteAllFood();
//         // }
//     }
// }