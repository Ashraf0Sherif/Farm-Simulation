using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlantProximityManager : MonoBehaviour
{
    public GameObject harrow;             // Reference to the Harrow prefab
    public GameObject tomatoBunchPrefab; // Reference to the Tomato_Bunch prefab
    public float detectionRadius = 2.0f; // Detection radius

    private void Update()
    {
        // Find all objects with the "Plant" tag
        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");

        foreach (GameObject plant in plants)
        {
            // Check distance between Harrow and each plant
            if (Vector3.Distance(harrow.transform.position, plant.transform.position) <= detectionRadius)
            {
                ReplaceWithTomatoBunch(plant);
            }
        }
    }

    private void ReplaceWithTomatoBunch(GameObject plant)
    {
        // Instantiate the Tomato_Bunch prefab at the plant's position and rotation
        GameObject tomatoBunch = Instantiate(tomatoBunchPrefab, plant.transform.position, plant.transform.rotation);

        // Make the Tomato_Bunch interactable with physics
        MakeInteractable(tomatoBunch);

        // Destroy the plant object
        Destroy(plant);
    }

private void MakeInteractable(GameObject tomatoBunch)
{
    // Ensure the object has a Collider (replace MeshCollider if necessary)
    Collider collider = tomatoBunch.GetComponent<Collider>();
    if (collider == null || collider is MeshCollider)
    {
        if (collider != null) Destroy(collider); // Remove the problematic collider
        tomatoBunch.AddComponent<BoxCollider>(); // Add a simple BoxCollider
    }

    // Add a Rigidbody for physics interaction
    Rigidbody rb = tomatoBunch.GetComponent<Rigidbody>();
    if (rb == null)
    {
        rb = tomatoBunch.AddComponent<Rigidbody>();
    }
    rb.useGravity = true; // Enable gravity
    rb.isKinematic = false; // Ensure it's not kinematic for physics interaction

    // Add the XR Grab Interactable component
    XRGrabInteractable grabInteractable = tomatoBunch.GetComponent<XRGrabInteractable>();
    if (grabInteractable == null)
    {
        grabInteractable = tomatoBunch.AddComponent<XRGrabInteractable>();
    }

    // Optional: Adjust grab interactable settings
    grabInteractable.throwOnDetach = true; // Allow objects to be thrown when released
    grabInteractable.interactionLayerMask = LayerMask.GetMask("Default"); // Set interaction layer
}
}