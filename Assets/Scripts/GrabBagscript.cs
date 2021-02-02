using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabBagscript : MonoBehaviour
{

    
    void OnTriggerEnter2D(Collider2D col)
    {
        BagNumber.bagAmount += 1;
        Destroy(gameObject);
    }

}
