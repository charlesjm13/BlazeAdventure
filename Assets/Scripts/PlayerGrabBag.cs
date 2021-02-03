using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBag : MonoBehaviour
{
    private int StartingBag;
 
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.bagAmount = StartingBag;
    }

    
}
