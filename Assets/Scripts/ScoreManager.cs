using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    Text text;
    public static int bagAmount;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bagAmount == 4)
        {
            bagAmount -= 4;
            
            PlayerLife.currentLife += 1;
            PlayerLife.Life = PlayerLife.currentLife;
            LifeManager.lifeAmount = PlayerLife.currentLife;
        }
        text.text = bagAmount.ToString();

    }
    
    
        
    
    
}

