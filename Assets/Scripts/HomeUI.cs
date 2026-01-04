
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(() =>
        {
            AppSceneManager.Instance.LoadScene("MainScene");
        });
    }

}
