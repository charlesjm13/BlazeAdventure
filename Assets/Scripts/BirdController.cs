using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{   
    public float MovementSpeed = -8;
    public Vector3 birdRespawnLocation;
    public Vector3 birdStartLocation;
    // Start is called before the first frame update
    void Start()
    {
       this.transform.position = birdStartLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x < -10)
        {
            birdRespawnLocation.y = this.transform.position.y + 1;
            if (birdRespawnLocation.y > 4)
            {
                birdRespawnLocation.y = -2;
            }
            this.transform.position = birdRespawnLocation;
        }
        else
        {
            this.transform.position += new Vector3(MovementSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
