using UnityEngine;
using UnityEngine.UI; // For UI-specific classes
using System.Collections.Generic;

public class TranslateUIObjectsOnClick : MonoBehaviour
{
    [Header("Reference UI Object (used for calculating height)")]
    public RectTransform referenceObject; // The UI object to use as a reference for calculating the height

    [Header("Target UI Objects (to be translated)")]
    public List<RectTransform> targetObjects = new List<RectTransform>(); // The list of target UI objects to translate

    private float translationOffsetY; // The calculated Y-axis translation offset based on the reference object's height

    // Function to calculate the height of the reference object
    private float CalculateReferenceHeight()
    {
        if (referenceObject != null)
        {
            float height = referenceObject.rect.height; // Get height from RectTransform
            Debug.Log($"Reference UI object height: {height}");
            return height;
        }

        Debug.LogWarning("Reference object is null. Please assign a reference RectTransform.");
        return 0f;
    }

    // Function to set the translation offset based on the reference object's height
    public void SetTranslationOffsetFromReference()
    {
        translationOffsetY = CalculateReferenceHeight(); // Calculate the height
        if (translationOffsetY > 0)
        {
            Debug.Log($"Translation offset (Y-axis) set to: {translationOffsetY} based on reference UI object.");
        }
        else
        {
            Debug.LogWarning("Translation offset not set due to missing or invalid reference object.");
        }
    }

    // Function to translate all target objects using the calculated Y-axis offset
    public void TranslateTargetObjects_UP()
    {
        if (translationOffsetY == 0f)
        {
            Debug.LogWarning("Translation offset is zero. Ensure you call SetTranslationOffsetFromReference first.");
            return;
        }

        foreach (var targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                // Translate the target UI object by the calculated offset along the Y-axis
                targetObject.anchoredPosition += new Vector2(0, translationOffsetY)/2;
                Debug.Log($"{targetObject.name} translated by: (0, {translationOffsetY})");
            }
        }
    }
    public void TranslateTargetObjects_Down()
    {
        if (translationOffsetY == 0f)
        {
            Debug.LogWarning("Translation offset is zero. Ensure you call SetTranslationOffsetFromReference first.");
            return;
        }

        foreach (var targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                // Translate the target UI object by the calculated offset along the Y-axis
                targetObject.anchoredPosition -= new Vector2(0, translationOffsetY)/2;
                Debug.Log($"{targetObject.name} translated by: (0, {translationOffsetY})");
            }
        }
    }
}
