using UnityEngine;
using DG.Tweening;

public class FuelFlowPath : MonoBehaviour
{
    public Transform[] waypoints;  // Waypoints defining the path
    public float duration = 5f;    // Time to travel the entire path
    public float rotationSpeed = 1f; // Speed of rotation

    private int currentWaypointIndex = 0;

    void Start()
    {
        StartAnimation();
    }

    public void StartAnimation()
    {
        MoveToNextWaypoint();
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        if (currentWaypointIndex >= waypoints.Length)
        {
            // Reset position and rotation for looping
            transform.localPosition = waypoints[0].localPosition;
            transform.localRotation = waypoints[0].localRotation;

            // Reset index to loop
            currentWaypointIndex = 0;
        }

        // Get the current and next waypoint
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        // Get the local position and rotation of the waypoints
        Vector3 targetPosition = targetWaypoint.localPosition;
        Quaternion targetRotation = targetWaypoint.localRotation;

        // Calculate segment duration
        float segmentDuration = duration / waypoints.Length;

        // Animate movement and rotation in local space
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOLocalMove(targetPosition, segmentDuration)
            .SetEase(Ease.Linear));
        
        // Rotate the circle towards the next waypoint's rotation in local space
        sequence.Join(transform.DOLocalRotateQuaternion(targetRotation, rotationSpeed)
            .SetEase(Ease.Linear));

        sequence.OnComplete(() =>
        {
            // Increment the waypoint index and move to the next waypoint
            currentWaypointIndex++;
            MoveToNextWaypoint();
        });
    }
}
