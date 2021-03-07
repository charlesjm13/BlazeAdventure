using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   
    public Text timerText;
    private float startTime;
    public string minutes;
    public string seconds;
    public int minPub = 0;
    public float secPub = 0;
    public float t;
    // Start is called before the first frame update
    void Start()
    {   
        minPub = PlayerPrefs.GetInt("mins");
        secPub = PlayerPrefs.GetFloat("secs");
        t = PlayerPrefs.GetFloat("t");
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
     t = Time.time - startTime;
     int minAdd = (int) (t/60);
     minPub = minPub + minAdd;
     minutes = minPub.ToString();
     float secAdd = (t%60);
     secPub = secPub + secAdd;
     seconds = secPub.ToString("f2");

    PlayerPrefs.SetFloat("t", t);
     PlayerPrefs.SetInt("mins", minAdd);
     PlayerPrefs.SetFloat("secs", secAdd);
     PlayerPrefs.Save();

     timerText.text = minutes + ":" + seconds;  
    }
}
