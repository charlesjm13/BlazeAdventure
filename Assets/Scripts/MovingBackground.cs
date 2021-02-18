using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float MovementSpeed = -1;
    public Vector3 backgroundRespawnLocation;
    public Vector3 backgroundStartLocation;
    public int backgroundStopLocation;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = backgroundStartLocation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= this.backgroundStopLocation)
        {
            this.MovementSpeed = 0;
        }
        else
        {
            this.transform.position += new Vector3(MovementSpeed, 0, 0) * Time.deltaTime;
        }
    }
}
