using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbag : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        ScoreManager.bagAmount += 1;
        Destroy(gameObject);
    }
    
}
