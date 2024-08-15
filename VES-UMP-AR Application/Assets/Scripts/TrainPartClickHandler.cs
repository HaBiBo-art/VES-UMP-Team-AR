using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrainPartClickHandler : MonoBehaviour
{
    public Material selectedMaterial;  // Assign this in the Unity Inspector
    private Material[] originalMaterials;
    private GameObject selectedObject;
    public Button showInteriorButton;

    private string selectedScene;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    HandleClick(hit.transform.gameObject);
                }
            }
        }
    }

    void HandleClick(GameObject clickedObject)
    {
        // Check if the clicked object is one of the specific parts
        if (clickedObject.name == "PilotCabin" || clickedObject.name == "PassengerCabin")
        {
            // Reset the previous object's material
            if (selectedObject != null)
            {
                ResetMaterials(selectedObject);
                showInteriorButton.gameObject.SetActive(false);
            }

            // Highlight the new selected object
            selectedObject = clickedObject;
            SetMaterials(selectedObject, selectedMaterial);

            // Determine which scene to load based on the clicked object
            if (clickedObject.name == "PilotCabin")
            {
                selectedScene = "PilotCabinInteriorScene";
            }
            else if (clickedObject.name == "PassengerCabin")
            {
                selectedScene = "PassengerCabinInteriorScene";
            }

            // Show the button only if a valid part is selected
            if (!string.IsNullOrEmpty(selectedScene))
            {
                showInteriorButton.gameObject.SetActive(true);
            }
        }
        else
        {
            // If the clicked object is not one of the specific parts, reset selection
            if (selectedObject != null)
            {
                ResetMaterials(selectedObject);
                selectedObject = null;
                showInteriorButton.gameObject.SetActive(false);
            }
        }
    }

    void SetMaterials(GameObject obj, Material material)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            // Save the original materials
            originalMaterials = objRenderer.materials;
            // Create a new array of the same length as the original materials
            Material[] newMaterials = new Material[originalMaterials.Length];
            // Replace all materials with the selected material
            for (int i = 0; i < newMaterials.Length; i++)
            {
                newMaterials[i] = material;
            }
            objRenderer.materials = newMaterials;
        }
    }

    void ResetMaterials(GameObject obj)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();
        if (objRenderer != null && originalMaterials != null)
        {
            // Reset the materials to the original ones
            objRenderer.materials = originalMaterials;
        }
    }

    public void OnShowInteriorButtonClick()
    {
        if (!string.IsNullOrEmpty(selectedScene))
        {
            SceneManager.LoadScene(selectedScene);
        }
    }
}
