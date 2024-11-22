using UnityEngine;
using System.Collections.Generic;

public class MoveObjectsOnClick : MonoBehaviour
{
    // Entry class to store object and its target position
    [System.Serializable]
    public class MoveEntry
    {
        public GameObject targetObject;  // The object to move
        public Vector3 targetPosition;   // The target position
    }

    // List of entries where each entry contains an object and its target position
    public List<MoveEntry> moveEntries = new List<MoveEntry>();

    // Function that moves all objects in the list to their respective positions
    public void MoveObjects()
    {
        foreach (var entry in moveEntries)
        {
            if (entry.targetObject != null)
            {
                // Move the object to the target position
                entry.targetObject.transform.position = entry.targetPosition;
                Debug.Log($"{entry.targetObject.name} moved to position: {entry.targetPosition}");
            }
        }
    }
}
