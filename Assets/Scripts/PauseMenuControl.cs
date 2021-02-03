using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    //public static bool PauseGame = false;

    public GameObject pauseMenu;

    public void ButtonPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        // PauseGame = true;
    }

    public void ButtonResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        // PauseGame = false;
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
