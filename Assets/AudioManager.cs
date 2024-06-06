using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public void Start()
    {
        audioSource.Play();
    }
    public void PlayAudio()
    {
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }
}