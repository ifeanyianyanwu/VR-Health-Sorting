using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // 1. Add this namespace

public class Food : MonoBehaviour
{

    // Variable to store the reference to the grab script
    private XRGrabInteractable grabInteractable;
    private UIManager uiManager;
    public string foodName;

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        // 2. Find the XRGrabInteractable component on this object
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with has the specific tag
        if (other.CompareTag("HealthyBowl"))
        {

            if (gameObject.CompareTag("HealthyFood"))
            {
                Debug.Log("Healthy food in healthy bowl!");
                uiManager.SetCorrectFoodCount();
            }else
            {
                Debug.Log("Unhealthy food in healthy bowl!");
                uiManager.SetIncorrectFoodCount(foodName, isHealthy: false);
            }

            Debug.Log("this food is in a healthy bowl.");
            DisableGrab(); // 3. Call the function to disable grabbing
        }
        else if (other.CompareTag("UnhealthyBowl"))
        {
            if (gameObject.CompareTag("UnhealthyFood"))
            {
                Debug.Log("Unhealthy food in unhealthy bowl!");
                uiManager.SetCorrectFoodCount();
            }else
            {
                Debug.Log("Healthy food in unhealthy bowl!");
                uiManager.SetIncorrectFoodCount(foodName, isHealthy: true);
            }
            Debug.Log("this food is in an unhealthy bowl.");
            DisableGrab();
        }
    }

    // Helper function to turn off the interaction
    private void DisableGrab()
    {
        if (grabInteractable != null)
        {
            // This prevents the player from grabbing it again
            grabInteractable.enabled = false;
            
            // Optional: If you want to force the hand to let go immediately 
            // if they are still holding it when it touches the bowl:
            // grabInteractable.interactionManager.SelectExit(grabInteractable.interactorsSelecting[0], grabInteractable);
        }
    }
}