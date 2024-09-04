using UnityEngine;

public class VehicleBoundary : MonoBehaviour
{
    private Transform vehicleTransform;  // Reference to the vehicle (deeply nested child) transform
    public Vector3 boundaryMin;          // Minimum bounds of the vehicle (local position relative to the vehicle's origin)
    public Vector3 boundaryMax;          // Maximum bounds of the vehicle (local position relative to the vehicle's origin)

    void Start()
    {
        // Assume the vehicle is already spawned and find it
        vehicleTransform = FindDeepChild(transform, "Vehicle"); // Adjust "Vehicle" to match the actual name of the vehicle object

        if (vehicleTransform == null)
        {
            Debug.LogError("Vehicle object not found.");
        }
    }

    void Update()
    {
        if (vehicleTransform == null)
        {
            return; // Exit if vehicle not found
        }

        // Calculate the player's position relative to the vehicle
        Vector3 localPosition = vehicleTransform.InverseTransformPoint(transform.position);

        // Clamp the player's local position within the defined bounds
        localPosition.x = Mathf.Clamp(localPosition.x, boundaryMin.x, boundaryMax.x);
        localPosition.y = Mathf.Clamp(localPosition.y, boundaryMin.y, boundaryMax.y);
        localPosition.z = Mathf.Clamp(localPosition.z, boundaryMin.z, boundaryMax.z);

        // Convert the clamped local position back to world coordinates
        transform.position = vehicleTransform.TransformPoint(localPosition);
    }

    // Recursive function to find a deeply nested child by name
    Transform FindDeepChild(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
                return child;

            Transform result = FindDeepChild(child, childName);
            if (result != null)
                return result;
        }
        return null;
    }
}
