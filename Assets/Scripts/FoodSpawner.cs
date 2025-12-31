using UnityEngine;
using System.Collections.Generic;

public class FoodSpawner : MonoBehaviour
{
    [Header("Healthy Prefabs")]
    public List<GameObject> healthyPrefabs = new List<GameObject>();

    [Header("Unhealthy Prefabs")]
    public List<GameObject> unhealthyPrefabs = new List<GameObject>();
    public List<GameObject> foods = new List<GameObject>();

    [Header("Spawn Points")]
    public List<Transform> spawnPoints = new List<Transform>();

    [Header("Spawn Settings")]
    public static int totalItemsToSpawn = 2; // spawn all at once

    [SerializeField] private UIManager uiManager;

    void Start()
    {
        DeleteAllFood();
    }

    public void SpawnAllFood()
    {
        GameManager.Instance.uiManager=uiManager;
        GameManager.Instance.foodSpawner=this;
        Food.DroppedFoodCount = 0;
        // Make a temporary list so original order stays untouched
        List<Transform> availablePoints = new List<Transform>(spawnPoints);

        // Shuffle spawn points Fisher-Yates style
        for (int i = 0; i < availablePoints.Count; i++)
        {
            int rand = Random.Range(i, availablePoints.Count);
            (availablePoints[i], availablePoints[rand]) = (availablePoints[rand], availablePoints[i]);
        }

        // Only spawn up to the number of unique points
        int spawnCount = Mathf.Min(totalItemsToSpawn, availablePoints.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnRandomFoodAtPoint(availablePoints[i]);
        }
    }

    void SpawnRandomFoodAtPoint(Transform spawnPoint)
    {
        // Pick category (50/50)
        bool spawnHealthy = Random.value > 0.5f;

        // Pick prefab from chosen category
        GameObject prefab = spawnHealthy ?
            healthyPrefabs[Random.Range(0, healthyPrefabs.Count)] :
            unhealthyPrefabs[Random.Range(0, unhealthyPrefabs.Count)];

        GameObject foodObject = Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        foods.Add(foodObject);
        Food foodScript = foodObject.GetComponent<Food>();
        if (foodScript != null)
        {
            foodScript.uiManager = uiManager;
        }
    }
    public void DeleteAllFood()
    {
        foreach (GameObject food in foods)
        {
            Destroy(food);
        }
        foods.Clear();
    }
}
