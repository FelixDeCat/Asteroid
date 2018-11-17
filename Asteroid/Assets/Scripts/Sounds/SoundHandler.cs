using UnityEngine;
using Tools.Sound;

public class SoundHandler
{
    AudioSource audioSource;

    public SoundHandler(AudioClip clip)
    {
        audioSource = ASourceCreator.Create2DSource(clip, "Source-> "+ clip.name);
    }

    public void OnNotify(int val)
    {
        audioSource.Play();
    }
}
