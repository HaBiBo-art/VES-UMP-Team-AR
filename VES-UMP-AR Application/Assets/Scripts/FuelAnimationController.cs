using UnityEngine;

public class FuelAnimationController : MonoBehaviour
{
    private FuelFlowManager[] fuelFlowManagers; // Array to hold all FuelFlowManager components

    void Start()
    {
        // Find all FuelFlowManager components within the children of this parent object
        fuelFlowManagers = GetComponentsInChildren<FuelFlowManager>();
    }

    // Method to be called by the button to start all animations
    public void StartAllFuelAnimations()
    {
        foreach (FuelFlowManager manager in fuelFlowManagers)
        {
            if (manager != null)
            {
                manager.StartFuelAnimation();
            }
        }
    }
}
