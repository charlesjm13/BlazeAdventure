using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    //public static int Life = 3;
    public static int currentLife;
    
    // Start is called before the first frame update
    void Start()
    {
        //currentLife = LifeManager.lifeAmount;
        //LifeManager.lifeAmount = Life;
        currentLife = PlayerPrefs.GetInt("lifeAmount");
    }
    
    void Update(){
        
            //currentLife -= death;
            //Life -= death;
            currentLife = PlayerPrefs.GetInt("lifeAmount");
        if (currentLife <= 0)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(5);
            Time.timeScale = 1;
            //Life = 3;
        }
        
        
    }

    

    
}
