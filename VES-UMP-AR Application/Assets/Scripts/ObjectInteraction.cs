using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float teleportDistance = 10f; // Distance to move the vehicle forward on its local z-axis

    void Update()
    {
        // Check if the user has tapped/clicked the screen
        if (Input.GetMouseButtonDown(0)) // 0 for left-click or first touch
        {
            // Create a ray from the camera to the point where the user clicked
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit by the ray is this door object
                if (hit.transform == transform)
                {
                    // Call the function to move the vehicle
                    TeleportVehicle();
                }
            }
        }
    }

    void TeleportVehicle()
    {
        // Move the parent vehicle forward on its local z-axis
        Transform vehicleTransform = transform.parent.parent.parent;
        if (vehicleTransform != null)
        {
            vehicleTransform.position += vehicleTransform.forward * teleportDistance;
            Debug.Log("Vehicle teleported forward by " + teleportDistance + " units on its local z-axis.");
        }
        else
        {
            Debug.LogError("Parent vehicle not found.");
        }
    }
}
