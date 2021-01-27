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
        if (this.player.position.y < 1.5)
        {
            this.transform.position = new Vector3(player.position.x + offset.x, 2, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(player.position.x + offset.x, this.player.position.y + offset.y, this.transform.position.z);
        }
    }    
}
