
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; 

public class Food : MonoBehaviour
{

    private XRGrabInteractable grabInteractable;
    public UIManager uiManager;
    public string foodName;

    public static int DroppedFoodCount = 0;


    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthyBowl"))
        {
            DroppedFoodCount++;
            if (gameObject.CompareTag("HealthyFood"))
            {
                uiManager.SetCorrectFoodCount();
            }else
            {
                uiManager.SetIncorrectFoodCount(foodName, isHealthy: false);
            }

            DisableGrab(); 
        }
        else if (other.CompareTag("UnhealthyBowl"))
        {
            DroppedFoodCount++;

            if (gameObject.CompareTag("UnhealthyFood"))
            {
                uiManager.SetCorrectFoodCount();
            }else
            {
                uiManager.SetIncorrectFoodCount(foodName, isHealthy: true);
            }
            DisableGrab();
        }

        if(DroppedFoodCount >= FoodSpawner.totalItemsToSpawn)
        {
            uiManager.EnableResultView();
            GameManager.Instance.isGameActive = false;
        }
    }

    private void DisableGrab()
    {
        if (grabInteractable != null)
        {
            grabInteractable.enabled = false;
            
            
        }
    }
}