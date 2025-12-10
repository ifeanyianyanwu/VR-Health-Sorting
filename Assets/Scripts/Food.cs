using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; // 1. Add this namespace

public class Food : MonoBehaviour
{
    // Variable to store the reference to the grab script
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // 2. Find the XRGrabInteractable component on this object
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object we collided with has the specific tag
        if (other.CompareTag("HealthyBowl"))
        {
            Debug.Log("this food is in a healthy bowl.");
            DisableGrab(); // 3. Call the function to disable grabbing
        }
        else if (other.CompareTag("UnhealthyBowl"))
        {
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