using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    public Color blue = new Color(71f/255f, 243f/255f, 255f/255f);
    public Color white = new Color(249f/255f, 247f/255f, 248f/255f);
    Camera cm;
    public Transform player;
    public int endOutdoor;
    public int startIndoor;

    // Start is called before the first frame update
    void Start()
    {
        cm = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.player.position.x < endOutdoor) {
            cm.backgroundColor = blue;
        }
        if (this.player.position.x > startIndoor)
        {
            cm.backgroundColor = white;
        }
    }
}
