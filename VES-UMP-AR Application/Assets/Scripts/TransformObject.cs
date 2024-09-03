using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformObject : MonoBehaviour
{
    public void ChangeZAxisPosition(float zOffset)
    {
        // Add the offset to the current Z-axis position
        Debug.Log("Door clicked!");
        transform.position += new Vector3(0f, 0f, zOffset);
    }

}

