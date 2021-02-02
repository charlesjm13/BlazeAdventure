using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningSceneControl : MonoBehaviour
{
    public void ButtonNewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonLeaderBoard()
    {
        SceneManager.LoadScene(6);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }


}
