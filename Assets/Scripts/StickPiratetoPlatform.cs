using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickPiratetoPlatform : MonoBehaviour
{
    public Transform platform;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(this.platform.position.x + offset.x, this.platform.position.y + offset.y, this.transform.position.z);
    }
}
