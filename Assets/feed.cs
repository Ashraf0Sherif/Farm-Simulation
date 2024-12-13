using UnityEngine;

public class ScaleOnProximity : MonoBehaviour
{
    public string plantTag = "feed_plant"; // Tag for plants
    public float proximityThreshold = 5f; // Distance within which scaling starts
    public float scaleStep = 0.1f; // Step size for scaling (amount to increase per step)
    public float scaleInterval = 1f; // Time interval between each scaling step
    public Animator sheepAnimator;

    private Vector3 initialScale = new Vector3(0.51386f, 0.51386f, 0.51386f); // Starting scale set to 0.51386 for X, Y, Z
    private Vector3 targetScale = new Vector3(1f, 1f, 1f); // Target final scale
    private Vector3 currentScale; // Current scale of the sheep
    private Transform sheepTransform;
    private float timeSinceLastScale = 0f; // Time tracker for the scaling intervals

    void Start()
    {
        sheepAnimator = GetComponent<Animator>();
        sheepTransform = transform;

        // Initialize the sheep to the specified starting scale
        currentScale = initialScale;
        sheepTransform.localScale = currentScale;

        // Check if the Animator is assigned
        if (sheepAnimator == null)
        {
            Debug.LogWarning("Animator not assigned or found on the object!");
        }
    }

    void Update()
    {
        // Find all plants with the specified tag
        GameObject[] plants = GameObject.FindGameObjectsWithTag(plantTag);

        bool isEating = false; // Track if the sheep is eating

        foreach (GameObject plant in plants)
        {
            // Calculate the distance between the sheep and the plant
            float distance = Vector3.Distance(sheepTransform.position, plant.transform.position);

            // If within the proximity threshold, scale up the sheep and play the eating animation
            if (distance <= proximityThreshold)
            {
                // Incremental scaling step-wise (scale up)
                if (timeSinceLastScale >= scaleInterval && currentScale.x < targetScale.x)
                {
                    // Increase scale step by step
                    currentScale = Vector3.Min(currentScale + new Vector3(scaleStep, scaleStep, scaleStep), targetScale);
                    sheepTransform.localScale = currentScale;

                    timeSinceLastScale = 0f; // Reset timer
                }

                // Play the eating animation (same approach as in AnimationController)
                if (sheepAnimator != null && !sheepAnimator.GetCurrentAnimatorStateInfo(0).IsName("Eating"))
                {
                    sheepAnimator.Play("eating");  // Play the eating animation
                }

                isEating = true;
                break; // Exit loop after finding one close plant
            }
        }

        // If no plant is within range, stop the eating animation (optional)
        if (!isEating && sheepAnimator != null && sheepAnimator.GetCurrentAnimatorStateInfo(0).IsName("Eating"))
        {
            sheepAnimator.StopPlayback(); // Optionally stop the animation
        }

        // Increase time since last scale (for step interval)
        timeSinceLastScale += Time.deltaTime;
    }
}
