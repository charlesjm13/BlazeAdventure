using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -10;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
