using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource backGroundSource;
    public AudioClip backGroundMusic;
    
    void Start()
    {
        backGroundSource.clip = backGroundMusic;
        backGroundSource.volume = 0.5f;
        backGroundSource.Play();
    }

    
}
