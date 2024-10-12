using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.EventSystems; // Import EventSystems for UI interaction detection

public class ObjectInteractionHandler : MonoBehaviour
{
    public TMP_Text labelUI; // Reference to your TextMeshPro Text component
    public Button selectObjectButton; // Button to enable object selection
    public Button unselectObjectButton; // Button to disable object selection
    public TMP_Text noObjectSelectedMessage; // Reference to the "No object selected" message
    public Material highlightMaterial; // Assign this in the Unity Inspector

    private GameObject selectedObject;
    private GameObject trainCabinInteriorPrefab; // Reference to your 3D model prefab
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>(); // Store original materials
    private bool selectionModeActive = false;
    public GameObject Obj_Name_Background;
    public GameObject NoObjectSelected_Bg;

    void Start()
    {
        // Ensure the "No object selected" message and "Unselect Objects" button are hidden initially
        noObjectSelectedMessage.gameObject.SetActive(false);
        unselectObjectButton.gameObject.SetActive(false);

        // Find the "Train cabin interior" prefab in the scene by name
        trainCabinInteriorPrefab = GameObject.Find("trainCabinInteriorPrefab");

        // Add listeners to the buttons
        selectObjectButton.onClick.AddListener(ActivateSelectionMode);
        unselectObjectButton.onClick.AddListener(DeactivateSelectionMode);
        Obj_Name_Background.SetActive(false);
        NoObjectSelected_Bg.SetActive(false);
    }

    void Update()
    {
        // Only handle object selection if we're in selection mode
        if (selectionModeActive && Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is over a UI element
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // If it's over a UI element, do nothing
                return;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HandleObjectSelection(hit.transform.gameObject);
                Obj_Name_Background.SetActive(true);
                NoObjectSelected_Bg.SetActive(false);
            }
            else
            {
                // If no object is hit, unhighlight the currently selected object
                if (selectedObject != null)
                {
                    UnhighlightObject(selectedObject);
                    selectedObject = null; // Clear the selected object reference
                    Obj_Name_Background.SetActive(false);
                    NoObjectSelected_Bg.SetActive(true);
                }
                ShowNoObjectSelectedMessage();
                
            }
        }
        // Enable and Disable the Box Collider of the "Train cabin interior" prefab (for the selection vizualisation)
        BoxCollider boxCollider = trainCabinInteriorPrefab.GetComponent<BoxCollider>();
    }

    public void ActivateSelectionMode()
    {
        selectionModeActive = true;
        ShowNoObjectSelectedMessage();
        selectObjectButton.gameObject.SetActive(false);
        unselectObjectButton.gameObject.SetActive(true);
        NoObjectSelected_Bg.SetActive(true);
        

    }

    void DeactivateSelectionMode()
    {
        selectionModeActive = false;
        HideLabel();
        noObjectSelectedMessage.gameObject.SetActive(false);
        Obj_Name_Background.SetActive(false);

        // Unhighlight the selected object if any
        if (selectedObject != null)
        {
            UnhighlightObject(selectedObject);
            selectedObject = null; // Clear the selected object reference
            
        }

        selectObjectButton.gameObject.SetActive(true);
        unselectObjectButton.gameObject.SetActive(false);
        NoObjectSelected_Bg.SetActive(false);
        

        // Unhide all objects in the "Train cabin interior" prefab
        foreach (Transform child in trainCabinInteriorPrefab.transform)
        {
            child.gameObject.SetActive(true);
        }

    }

    void HandleObjectSelection(GameObject touchedObject)
    {
        // Unhighlight previously selected object if any
        if (selectedObject != null)
        {
            UnhighlightObject(selectedObject);
        }

        // Highlight the new selected object
        selectedObject = touchedObject;
        HighlightObject(selectedObject);

        // Update the label with the object's name
        labelUI.text = touchedObject.name;
        labelUI.gameObject.SetActive(true); // Ensure the label is visible

        // Hide the "No object selected" message
        noObjectSelectedMessage.gameObject.SetActive(false);
    }

    void HighlightObject(GameObject obj)
    {
        // Find all renderer components in the object and its children
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            // Save the original material
            if (!originalMaterials.ContainsKey(renderer))
            {
                originalMaterials[renderer] = renderer.material;
            }
            // Apply the highlight material
            renderer.material = highlightMaterial;
        }
    }

    void UnhighlightObject(GameObject obj)
    {
        // Find all renderer components in the object and its children
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (originalMaterials.TryGetValue(renderer, out Material originalMaterial))
            {
                // Reset to original material
                renderer.material = originalMaterial;
            }
        }
        // Clear the original materials dictionary
        originalMaterials.Clear();
    }

    public void ShowNoObjectSelectedMessage()
    {
        labelUI.gameObject.SetActive(false);
        noObjectSelectedMessage.gameObject.SetActive(true);
        
    }

    void HideLabel()
    {
        labelUI.gameObject.SetActive(false);
    }
}

