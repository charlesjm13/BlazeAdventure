using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFlipped : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
