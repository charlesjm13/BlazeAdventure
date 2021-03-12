using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class grabbag : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")){
        int grab = PlayerPrefs.GetInt("grabbags");    
        PlayerPrefs.SetInt("grabbags" , grab + 1);
        PlayerPrefs.Save();
        Destroy(gameObject);
        }
    }
    
}
