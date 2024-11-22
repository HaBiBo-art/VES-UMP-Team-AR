using UnityEngine;
using System.Collections.Generic;

public class TranslateObjectsOnClick : MonoBehaviour
{
    // Entry class to store object and its translation (offset)
    [System.Serializable]
    public class TranslateEntry
    {
        public GameObject targetObject;  // The object to move
        public Vector3 translationOffset;   // The offset by which to move the object
    }

    // List of entries where each entry contains an object and its translation offset
    public List<TranslateEntry> translateEntries = new List<TranslateEntry>();

    // Function that translates all objects in the list by their respective offsets
    public void TranslateObjects()
    {
        foreach (var entry in translateEntries)
        {
            if (entry.targetObject != null)
            {
                // Translate the object by the offset
                entry.targetObject.transform.Translate(entry.translationOffset);
                Debug.Log($"{entry.targetObject.name} translated by: {entry.translationOffset}");
            }
        }
    }
}
