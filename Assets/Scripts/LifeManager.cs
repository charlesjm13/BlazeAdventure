using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    Text text;
    public static int lifeAmount;
    // Start is called before the first frame update
    void Start()
    {
        lifeAmount = PlayerPrefs.GetInt("lifeAmount");
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeAmount = PlayerPrefs.GetInt("lifeAmount");
        text.text = lifeAmount.ToString();
    }
}
