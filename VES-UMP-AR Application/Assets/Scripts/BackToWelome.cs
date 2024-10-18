using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateToWelcomeScreen : MonoBehaviour
{
    public void GoBackToWelcomeScreen()
    {
        // Reload the main scene named "MainScene", reinitializing all AR components
        SceneManager.LoadScene("WelcomeScreen");
    }

}


