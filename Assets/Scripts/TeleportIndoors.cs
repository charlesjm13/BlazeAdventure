using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportIndoors : MonoBehaviour
{
    public Transform player;
    public Vector3 indoorLocation;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            this.player.transform.position = new Vector3(indoorLocation.x, indoorLocation.y, indoorLocation.z);
        }
    }
}
