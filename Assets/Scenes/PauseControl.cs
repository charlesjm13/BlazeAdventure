using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{

    public void ButtonResume()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonSettings()
    {
        SceneManager.LoadScene(2);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }

   
}
