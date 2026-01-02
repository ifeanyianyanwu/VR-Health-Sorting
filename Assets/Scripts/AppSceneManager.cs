using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // This is Unity's SceneManager
using UnityEngine.UI; 

// 1. Rename the class to avoid conflict
public class AppSceneManager : MonoBehaviour
{
    // 2. Update the Singleton type
    public static AppSceneManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    // --- Public Methods ---

    public void LoadScene(string sceneName)
    {
        // 3. Now "SceneManager" correctly refers to Unity's built-in class
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneRoutine(sceneName));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Application...");
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    // --- Internal Logic ---

    private IEnumerator LoadSceneRoutine(string sceneName)
    {
        // 4. Use the full name just to be safe, though SceneManager.LoadSceneAsync works too now
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            // Add your slider update logic here if needed
            yield return null;
        }
    }
}