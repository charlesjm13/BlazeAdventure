using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Highscore : MonoBehaviour
{
    public Text score;
    public Text highScore; 

    void Start()
    {
        KillScore();
        highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }

    public void KillScore()
    {
        int number = PlayerPrefs.GetInt("kills");
        score.text = number.ToString();

        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("Highscore", number);
            highScore.text = number.ToString(); 
        }
    }

    /*public void Reset()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highScore.text = "0";
    }*/
}
