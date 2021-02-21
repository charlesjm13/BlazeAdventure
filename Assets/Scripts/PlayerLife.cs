using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public static int Life = 2;
    public static int currentLife;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLife = Life;
        LifeManager.lifeAmount = Life;
    }
    
   

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Enemy") || coll.gameObject.CompareTag("Spikes"))
        {
            Die(1);
        }
    }
    // Update is called once per frame
    void Die(int death)
    {
       
        
            currentLife -= death;
            Life -= death;
        if (Life <= 0)
        {
            SceneManager.LoadScene(5);
        }
        else
        {
            LifeManager.lifeAmount = currentLife;
        }
        
    }

    

    
}
