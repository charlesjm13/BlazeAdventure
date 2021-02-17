using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningAudioScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip winFanfare;
    public AudioClip winMusic;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(winFanfare, 1);
        audioSource.PlayOneShot(winMusic, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
