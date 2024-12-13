using UnityEngine;

public class PlantSheepCollision : MonoBehaviour
{
    public string plantTag = "Plant_Large"; // Tag of the plant prefab
    public string sheepTag = "Sheep";      // Tag of the sheep
    public float destroyDistance = 2f;     // Distance at which the plant will be destroyed

    private void Update()
    {
        // Find all game objects with the "Sheep" tag
        GameObject sheep = GameObject.FindGameObjectWithTag(sheepTag);
        
        if (sheep != null)
        {
            // Calculate the distance between this object and the sheep
            float distance = Vector3.Distance(transform.position, sheep.transform.position);
            
            // If the distance is less than the specified threshold, destroy the plant
            if (distance <= destroyDistance)
            {
                Destroy(gameObject); // Destroy the plant
            }
        }
    }
}
