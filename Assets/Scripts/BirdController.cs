using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{   
    public float MovementSpeed = -8;
    public Vector3 birdLocation;
    // Start is called before the first frame update
    void Start()
    {
       this.transform.position = birdLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < -10)
        {
            birdLocation.y += 1;
            if (birdLocation.y > 4)
            {
                birdLocation.y = -2;
            }
            this.transform.position = birdLocation;
        }
        else
        {
            this.transform.position += new Vector3(MovementSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
