using UnityEngine;

namespace Ursaanimation.CubicFarmAnimals
{
    public class AnimationController : MonoBehaviour
    {
        public Animator animator;
        public string[] animations; // Array of animation names for random selection

        public float animationInterval = 8f; // Time between animations
        public float moveSpeed = 0.5f; // Movement speed for the NPC
        public float detectionRadius = 0.5f; // Radius to detect colliders
        public LayerMask detectionLayer; // Layer to detect specific objects (e.g., colliders)

        public bool isMoving = false; // Flag to indicate if the NPC is currently moving

        void Start()
        {
            animator = GetComponent<Animator>();
            animations = new string[] {
                "walk_forward",
                "turn_90_L",
                "turn_90_R",
                "sit_to_stand",
                "stand_to_sit","eating"
            };

            // Start the coroutine for random animation
            StartCoroutine(RandomlyPlayAnimation());
        }

        void Update()
        {
            if (isMoving)
            {
                // Check for nearby colliders and react if necessary
                CheckForObstacles();
                
                // Continue moving forward if no obstacle
                MoveForward();
            }
        }

        private void MoveForward()
        {
            // Move the NPC forward in its local space
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

        private void CheckForObstacles()
        {
            // Detect colliders in the specified radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, detectionLayer);

            if (hitColliders.Length > 0)
            {
                // Find the closest collider
                Collider closestCollider = hitColliders[0];
                float closestDistance = Vector3.Distance(transform.position, closestCollider.transform.position);

                foreach (Collider collider in hitColliders)
                {
                    float distance = Vector3.Distance(transform.position, collider.transform.position);
                    if (distance < closestDistance)
                    {
                        closestCollider = collider;
                        closestDistance = distance;
                    }
                }

                // Calculate the direction to move away
                Vector3 directionToCollider = closestCollider.transform.position - transform.position;

                // Decide the new direction based on the position of the collider
                if (Vector3.Dot(transform.right, directionToCollider) > 0) // Collider is on the right
                {
                    TurnLeft();
                }
                else if (Vector3.Dot(transform.right, directionToCollider) < 0) // Collider is on the left
                {
                    TurnRight();
                }
                else // Collider is directly in front
                {
                    TurnBack();
                }
            }
        }

        private void TurnLeft()
        {
            animator.Play("turn_90_L");
            transform.Rotate(Vector3.up, -90f); // Rotate left
        }

        private void TurnRight()
        {
            animator.Play("turn_90_R");
            transform.Rotate(Vector3.up, 90f); // Rotate right
        }

        private void TurnBack()
        {
            animator.Play("turn_90_L"); // Play a left turn animation
            transform.Rotate(Vector3.up, 180f); // Turn around
        }

        private System.Collections.IEnumerator RandomlyPlayAnimation()
        {
            while (true)
            {
                // Select a random animation
                string randomAnimation = animations[Random.Range(0, animations.Length)];

                // Determine if the NPC should move
                if (randomAnimation == "walk_forward")
                {
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }

                // Play the selected animation
                animator.Play(randomAnimation);

                // Wait for the duration of the animation or the interval
                yield return new WaitForSeconds(animationInterval);
            }
        }
    }
}
