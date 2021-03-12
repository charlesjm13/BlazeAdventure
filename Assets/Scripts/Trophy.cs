using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy : MonoBehaviour
{   
    void Awake(){
            int highkills = PlayerPrefs.GetInt("kills");
            PlayerPrefs.SetInt("highkills", highkills);
            PlayerPrefs.Save();
            PlayerPrefs.DeleteKey("lifeAmount");
            PlayerPrefs.DeleteKey("playerPositionX");
            PlayerPrefs.DeleteKey("playerPositionY");
            PlayerPrefs.DeleteKey("died");
            PlayerPrefs.DeleteKey("checkpointed");
            PlayerPrefs.DeleteKey("kills");
            PlayerPrefs.DeleteKey("grabbags");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(3);
        //PlayerPrefs.DeleteAll();
    
    }
    
}
