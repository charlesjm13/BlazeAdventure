using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlaform : MonoBehaviour
{
    public Vector3 floatPosition;
    public int leftMargin;
    public int rightMargin;
    public int direction = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= rightMargin)
        {
            transform.position -= floatPosition;
            direction = 1;
        }
        else if (this.transform.position.x <= leftMargin)
        {
            transform.position += floatPosition;
            direction = 0;
        }      
        else
        {
            if (direction == 0)
            {
                transform.position += floatPosition;
            }
            if (direction == 1)
            {
                transform.position -= floatPosition;
            }
        }
       
    }
}

