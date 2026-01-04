using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class FoodLabelController : MonoBehaviour
{
    [Header("UI Reference")]
    [Tooltip("Drag the Canvas object attached to this food item here.")]
    [SerializeField] private GameObject labelCanvas; 
    [SerializeField] private XRGrabInteractable grabInteractable;
    [SerializeField] private Food foodItem;
    [SerializeField] private TextMeshProUGUI foodNameText;

    private Camera mainCamera;

    // CHANGE 1: Use Awake for initialization so references are ready for OnEnable
    void Awake()
    {
        // Try to get components if they weren't assigned in Inspector
        if (grabInteractable == null) grabInteractable = GetComponent<XRGrabInteractable>();
        if (foodItem == null) foodItem = GetComponent<Food>();
        
        // Find canvas and text if not assigned
        if (labelCanvas == null) labelCanvas = GetComponentInChildren<Canvas>(true)?.gameObject;
        if (foodNameText == null && labelCanvas != null) 
            foodNameText = labelCanvas.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    void Start()
    {
        mainCamera = Camera.main;

        // Ensure label is hidden at start
        if(labelCanvas != null) labelCanvas.SetActive(false); 
        
        // Set the food name text
        if(foodNameText != null && foodItem != null)
        {
            foodNameText.text = foodItem.foodName;
        }
    }

    void OnEnable()
    {
        // Subscribe to XR Interaction events
        if(grabInteractable != null)
        {
            // Note: In newer XR Toolkit versions, 'args' is required. 
            // In older versions (pre-2.0), it might be parameterless.
            grabInteractable.hoverEntered.AddListener(OnHoverEnter);
            grabInteractable.hoverExited.AddListener(OnHoverExit);
             // Added based on previous request
        }
    }

    void OnDisable()
    {
        // Unsubscribe from XR Interaction events
        if(grabInteractable != null)
        {
            grabInteractable.hoverEntered.RemoveListener(OnHoverEnter);
            grabInteractable.hoverExited.RemoveListener(OnHoverExit);
   
        }
    }

    void Update()
    {
        // Billboarding
        if (labelCanvas != null && labelCanvas.activeSelf && mainCamera != null)
        {
            labelCanvas.transform.LookAt(labelCanvas.transform.position + mainCamera.transform.rotation * Vector3.forward,
                                         mainCamera.transform.rotation * Vector3.up);
        }
    }

    // --- Event Methods ---
    // Note: To match the Listener signature, these usually take (HoverEnterEventArgs args)
    // But since you used a lambda (args) => ... in your original code, your parameterless void works fine.
    // I updated the AddListener above to point directly to these functions for cleaner code.
    // If you get a signature error, change these to: public void OnHoverEnter(HoverEnterEventArgs args)

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        if(labelCanvas != null) labelCanvas.SetActive(true);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        if(labelCanvas != null) labelCanvas.SetActive(false);
    }
    
  
}