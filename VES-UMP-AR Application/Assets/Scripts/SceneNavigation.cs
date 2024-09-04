using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public void GoBackToMainScene()
    {
        // Reload the main scene named "MainScene", reinitializing all AR components
        SceneManager.LoadScene("MainScene");
    }

}


