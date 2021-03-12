using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{   
    void Awake(){
        PlayerPrefs.DeleteAll();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(3);
        //PlayerPrefs.DeleteAll();
    
    }
    
}
