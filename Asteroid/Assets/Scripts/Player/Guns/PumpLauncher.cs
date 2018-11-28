using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extensions;
using Tools.Sound;
using System;

public class PumpLauncher : GunBase {

    public Transform pointToShoot;
    public Bomb bomb;

    public AudioClip clip_bomb;
    AudioSource as_bomb;

    public int bombConsume = 80;
    public float bombForce = 2;

    private void Awake()
    {
        as_bomb = ASourceCreator.Create2DSource(clip_bomb, "bomb");
    }

    public override void OnPress()
    {
        if (em.Consume(bombConsume))
        {
            as_bomb.Play();
            bomb.Launch(pointToShoot.transform.position, pointToShoot.transform.up, bombForce);
        }
    }

    public override void OnRelease()
    {
        //nada x ahora
    }
}
