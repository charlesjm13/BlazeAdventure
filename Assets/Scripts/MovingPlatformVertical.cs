using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{


    public Vector3 floatPosition;
    public int topMargin;
    public int bottomMargin;
    public int direction = 0;


    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= topMargin)
        {
            transform.position -= floatPosition;
            direction = 1;
        }
        else if (this.transform.position.y <= bottomMargin)
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

