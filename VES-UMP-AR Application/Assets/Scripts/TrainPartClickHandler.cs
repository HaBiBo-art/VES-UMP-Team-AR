using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainPartClickHandler : MonoBehaviour
{
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
        if (clickedObject.name == "PilotCabin")
        {
            SceneManager.LoadScene("PilotCabinInteriorScene");
        }
        else if (clickedObject.name == "PassengerCabin")
        {
            SceneManager.LoadScene("PassengerCabinInteriorScene");
        }
    }
}

