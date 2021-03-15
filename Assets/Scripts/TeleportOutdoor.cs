using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOutdoor : MonoBehaviour
{
    public Transform player;
    public Vector3 outdoorLocation;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
            this.player.transform.position = new Vector3(outdoorLocation.x, outdoorLocation.y, outdoorLocation.z);
        }
    }
}
