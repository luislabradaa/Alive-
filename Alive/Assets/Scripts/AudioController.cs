using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioClip audioClip;
    public AudioSource audioSource;

    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.loop = true;
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
