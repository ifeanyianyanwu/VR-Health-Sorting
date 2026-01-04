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

    void Awake()
    {
        if (grabInteractable == null) grabInteractable = GetComponent<XRGrabInteractable>();
        if (foodItem == null) foodItem = GetComponent<Food>();
        
        if (labelCanvas == null) labelCanvas = GetComponentInChildren<Canvas>(true)?.gameObject;
        if (foodNameText == null && labelCanvas != null) 
            foodNameText = labelCanvas.GetComponentInChildren<TextMeshProUGUI>(true);
    }

    void Start()
    {
        mainCamera = Camera.main;

        if(labelCanvas != null) labelCanvas.SetActive(false); 
        
        if(foodNameText != null && foodItem != null)
        {
            foodNameText.text = foodItem.foodName;
        }
    }

    void OnEnable()
    {
        if(grabInteractable != null)
        {
       
            grabInteractable.hoverEntered.AddListener(OnHoverEnter);
            grabInteractable.hoverExited.AddListener(OnHoverExit);
            grabInteractable.selectEntered.AddListener(OnSelectEnter);
            
        }
    }

    void OnDisable()
    {
        if(grabInteractable != null)
        {
            grabInteractable.hoverEntered.RemoveListener(OnHoverEnter);
            grabInteractable.hoverExited.RemoveListener(OnHoverExit);
            grabInteractable.selectEntered.RemoveListener(OnSelectEnter);
            
        }
    }

    void Update()
    {
        if (labelCanvas != null && labelCanvas.activeSelf && mainCamera != null)
        {
            labelCanvas.transform.LookAt(labelCanvas.transform.position + mainCamera.transform.rotation * Vector3.forward,
                                         mainCamera.transform.rotation * Vector3.up);
        }
    }



    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        if(labelCanvas != null) labelCanvas.SetActive(true);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        if(labelCanvas != null) labelCanvas.SetActive(false);
    }
    
    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        if(labelCanvas != null) labelCanvas.SetActive(false);
    }

   
}