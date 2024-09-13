using UnityEngine;

public class InjectorCollision : MonoBehaviour
{
    public ParticleSystem particleSystem;  // Drag and drop the particle system in the inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Piston"))  // Make sure your piston object has a tag "Piston"
        {
            // Play the particle system
            if (particleSystem != null)
            {
                particleSystem.Play();
            }
        }
    }
}
