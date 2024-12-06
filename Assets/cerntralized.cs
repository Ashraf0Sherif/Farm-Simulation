using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SeedManager : MonoBehaviour
{
    public GameObject plantSmallPrefab;        // Prefab for Plant_Small
    public GameObject plantMediumPrefab;      // Prefab for Plant_Medium
    public GameObject plantTomatoMediumPrefab; // Prefab for Plant_Tomato_Medium
    public GameObject plantTomatoLargePrefab;  // Prefab for Plant_Tomato_Large
    public float growthDistance = 2f;          // Distance to detect the WaterCan
    public float growthTime = 5f;              // Time between each growth stage in seconds

    private GameObject waterCan;               // Reference to the WaterCan
    private List<GrowingPlant> growingPlants = new List<GrowingPlant>(); // Track plants in progress

    void Start()
    {
        // Find all seeds with the "Seed" tag and initialize them
        GameObject[] seedObjects = GameObject.FindGameObjectsWithTag("Seed");
        foreach (GameObject seed in seedObjects)
        {
            growingPlants.Add(new GrowingPlant(seed, GrowthStage.Seed));
        }

        // Find the WaterCan in the scene
        waterCan = GameObject.FindWithTag("WaterCan");
    }

    void Update()
    {
        if (waterCan == null) return;

        for (int i = growingPlants.Count - 1; i >= 0; i--)
        {
            GrowingPlant plant = growingPlants[i];

            if (plant.GameObject == null)
            {
                // Remove destroyed plants from the list
                growingPlants.RemoveAt(i);
                continue;
            }

            // Check proximity for watering
            float distance = Vector3.Distance(plant.GameObject.transform.position, waterCan.transform.position);

            if (distance <= growthDistance && !plant.IsGrowing)
            {
                StartCoroutine(GrowPlant(plant));
            }
        }
    }

    IEnumerator GrowPlant(GrowingPlant plant)
    {
        plant.IsGrowing = true;

        // Wait for the growth time
        yield return new WaitForSeconds(growthTime);

        // Advance to the next growth stage
        switch (plant.Stage)
        {
            case GrowthStage.Seed:
                ReplacePlant(plant, plantSmallPrefab, GrowthStage.PlantSmall);
                break;
            case GrowthStage.PlantSmall:
                ReplacePlant(plant, plantMediumPrefab, GrowthStage.PlantMedium);
                break;
            case GrowthStage.PlantMedium:
                ReplacePlant(plant, plantTomatoMediumPrefab, GrowthStage.PlantTomatoMedium);
                break;
            case GrowthStage.PlantTomatoMedium:
                ReplacePlant(plant, plantTomatoLargePrefab, GrowthStage.PlantTomatoLarge);
                break;
            default:
                Debug.Log("Plant has reached the final stage!");
                break;
        }

        plant.IsGrowing = false;
    }

    private void ReplacePlant(GrowingPlant plant, GameObject nextPrefab, GrowthStage nextStage)
{
    // Store position and rotation before destroying the object
    Vector3 position = plant.GameObject.transform.position;
    Quaternion rotation = plant.GameObject.transform.rotation;

    // Destroy the old plant
    Destroy(plant.GameObject);

    // Instantiate the next stage prefab
    GameObject newPlant = Instantiate(nextPrefab, position, rotation);

    // Update the GrowingPlant properties
    plant.GameObject = newPlant;
    plant.Stage = nextStage;
}
}

// Enum for growth stages
public enum GrowthStage
{
    Seed,
    PlantSmall,
    PlantMedium,
    PlantTomatoMedium,
    PlantTomatoLarge
}

// Class to track growing plants
public class GrowingPlant
{
    public GameObject GameObject { get; set; }
    public GrowthStage Stage { get; set; }
    public bool IsGrowing { get; set; }

    public GrowingPlant(GameObject gameObject, GrowthStage stage)
    {
        GameObject = gameObject;
        Stage = stage;
        IsGrowing = false;
    }
}