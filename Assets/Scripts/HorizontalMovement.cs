using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float speed = 10;


    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey("a"))
        {
            position.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            position.x += speed * Time.deltaTime;
        }

        transform.position = position;
    }
}
