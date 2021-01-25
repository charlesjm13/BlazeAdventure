using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {   
        this.transform.position = new Vector3(player.position.x + offset.x, this.transform.position.y, this.transform.position.z);
    }
        
        
}
