using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressFtoRead : MonoBehaviour
{
    public static bool signRead;

    void Start ()
    {
        signRead = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            signRead = true;
        }
    }
}
