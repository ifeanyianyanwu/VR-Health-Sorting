using UnityEngine;

public class Basket : MonoBehaviour
{
    // Set this in the Inspector: "HealthyFood" or "UnhealthyFood"
    public string targetTag; 

    private void OnTriggerEnter(Collider other)
    {
        // 1. Check if the object falling in matches the target tag
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Correct placement! +10 Points");
            
            // Destroy the food object
            Destroy(other.gameObject); 
        }
        // 2. Optional: Handle wrong food placement
        else if (other.CompareTag("HealthyFood") || other.CompareTag("UnhealthyFood"))
        {
            Debug.Log("Wrong basket! -5 Points");
            
            // Destroy it anyway to clear the scene, or eject it
            Destroy(other.gameObject);
        }
    }
}