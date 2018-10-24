using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Sound;

public class SoundHandler : IObserver
{
    AudioSource audioSource;

    public SoundHandler(AudioClip clip)
    {
        audioSource = ASourceCreator.Create2DSource(clip, "Source-> "+ clip.name);
    }

    public void Initialize(object obj = null)
    {
        
    }

    public void Notify(object obj = null)
    {
        audioSource.Play();
    }
}
