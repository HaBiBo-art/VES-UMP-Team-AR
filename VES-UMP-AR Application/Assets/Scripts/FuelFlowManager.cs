using UnityEngine;
using System.Collections;

public class FuelFlowManager : MonoBehaviour
{
    public Transform[] waypoints;  // Waypoints defining the path
    public GameObject[] circles;  // Array of circles to animate
    public float duration = 5f;    // Time to travel the entire path
    public float rotationSpeed = 1f; // Speed of rotation
    public float spacing = 1f; // Spacing between circles
    public float startDelay = 0.5f; // Delay between each circle's animation start

    void Start()
    {
        StartCoroutine(StartCirclesWithDelay());
    }

    private IEnumerator StartCirclesWithDelay()
    {
        // Ensure circles are initialized properly
        for (int i = 0; i < circles.Length; i++)
        {
            GameObject circle = circles[i];
            FuelFlowPath path = circle.GetComponent<FuelFlowPath>();

            // Add the FuelFlowPath component if not present
            if (path == null)
            {
                path = circle.AddComponent<FuelFlowPath>();
            }

            // Set circle parameters
            path.waypoints = waypoints;
            path.duration = duration;
            path.rotationSpeed = rotationSpeed;

            // Set the circle's initial position correctly
            Vector3 startPosition = CalculateStartPosition(i);
            circle.transform.position = startPosition;

            // Reset circle’s position to start of the path
            circle.transform.position = waypoints[0].position;
            
            // Make sure circles are not affected by any animation until it's their turn
            circle.transform.gameObject.SetActive(false);
            
            // Start the animation with a staggered delay
            float delay = i * startDelay;
            yield return new WaitForSeconds(delay);

            // Activate the circle and start the animation
            circle.transform.gameObject.SetActive(true);
            path.StartAnimation();
        }
    }

    Vector3 CalculateStartPosition(int index)
    {
        // Ensure that circles are properly spaced along the path
        if (waypoints.Length == 0) return Vector3.zero;

        // Calculate position based on spacing
        float t = (float)index / (circles.Length - 1);
        Vector3 startPoint = waypoints[0].position;
        Vector3 endPoint = waypoints[waypoints.Length - 1].position;

        return Vector3.Lerp(startPoint, endPoint, t);
    }
}
