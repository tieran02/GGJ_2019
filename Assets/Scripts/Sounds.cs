using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource Music;

    bool isPlaying = false;

    private void Awake()
    { 
        DontDestroyOnLoad(transform.gameObject);
        Music = GetComponent<AudioSource>();

        var objects = FindObjectsOfType<Sounds>();
        if (objects.Length > 1)
            Destroy(objects[objects.Length - 1]);
    }

    public void PlayMusic()
    {
        if (Music.isPlaying) return;
        Music.Play();
    }

    public void StopMusic()
    {
        Music.Stop();
    }

    private void Start()
    {
        if (isPlaying == false)
        {
            PlayMusic();
            isPlaying = true;
        }
    } 
}

