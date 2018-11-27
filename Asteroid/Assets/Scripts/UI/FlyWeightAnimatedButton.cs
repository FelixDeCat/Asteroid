using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Sound;

public class FlyWeightAnimatedButton : MonoBehaviour
{

    public AudioClip MouseOverSound;
    AudioSource asourceMouseOver;

    public AudioClip MouseClickSound;
    AudioSource asourceMouseClick;

    void Awake()
    {
        if (MouseOverSound != null) asourceMouseOver = ASourceCreator.Create2DSource(MouseOverSound, "Source-> " + MouseOverSound.name);
        if (MouseClickSound != null) asourceMouseClick = ASourceCreator.Create2DSource(MouseClickSound, "Source-> " + MouseClickSound.name);
    }

    public void PlayMouseOver() { asourceMouseOver.Play(); }
    public void PlayMouseClick() { if (asourceMouseClick != null) asourceMouseClick.Play(); }
}
