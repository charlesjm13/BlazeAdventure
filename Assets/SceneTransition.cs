using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    
    void Update()
    {
        if (Input.GetButton("BStart"))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        StartCoroutine(LoadLevel(1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        //Wait for animation to play
        yield return new WaitForSeconds(transitionTime);
        //Load the new scene
        SceneManager.LoadScene(levelIndex);
    }
}
