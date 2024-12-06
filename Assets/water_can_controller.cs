using UnityEngine;

public class WaterCanController : MonoBehaviour
{
    public ParticleSystem waterParticles; // Reference to the Particle System
    public KeyCode pourKey = KeyCode.Space; // Key to pour water (change for VR controller input)

    void Update()
    {
        if (Input.GetKeyDown(pourKey))
        {
            StartWatering();
        }
        else if (Input.GetKeyUp(pourKey))
        {
            StopWatering();
        }
    }

    public void StartWatering()
    {
        if (!waterParticles.isPlaying)
        {
            waterParticles.Play();
        }
    }

    public void StopWatering()
    {
        if (waterParticles.isPlaying)
        {
            waterParticles.Stop();
        }
    }
}