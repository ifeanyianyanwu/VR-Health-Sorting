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
    public static int totalItemsToSpawn = 10; 

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
        List<Transform> availablePoints = new List<Transform>(spawnPoints);

        for (int i = 0; i < availablePoints.Count; i++)
        {
            int rand = Random.Range(i, availablePoints.Count);
            (availablePoints[i], availablePoints[rand]) = (availablePoints[rand], availablePoints[i]);
        }

        int spawnCount = Mathf.Min(totalItemsToSpawn, availablePoints.Count);

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnRandomFoodAtPoint(availablePoints[i]);
        }
    }

    void SpawnRandomFoodAtPoint(Transform spawnPoint)
    {
        bool spawnHealthy = Random.value > 0.5f;

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
