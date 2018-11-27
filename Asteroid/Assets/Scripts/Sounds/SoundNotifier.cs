using UnityEngine;
using Tools.Sound;

public class SoundNotifier
{
    AudioSource audioSource;

    public SoundNotifier(AudioClip clip)
    {
        audioSource = ASourceCreator.Create2DSource(clip, "Source-> "+ clip.name);
    }

    public void OnNotify(int val)
    {
        audioSource.Play();
    }
}
