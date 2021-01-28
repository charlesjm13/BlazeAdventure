using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsRead : MonoBehaviour
{
    public Text PressSpacebar;
    public Text PressF;

    void Start()
    {
        PressF.enabled = true;
        PressSpacebar.enabled = false;
    }

    void Update()
    {

        if(pressFtoRead.signRead == true)
        {
            PressF.enabled = false;
            PressSpacebar.enabled = true;
        }
    }
}
