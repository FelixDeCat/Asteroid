using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Sound;

public class Laser : GunBase
{

    public GameObject laser;

    public float cant_consume = 1.5f;
    public float sizeYlaser = 1;
    public float sizeXlaser = 0.6f;

    public AudioClip clip_laser;
    AudioSource as_laser;

    private void Awake()
    {
        laser.gameObject.SetActive(false);

        as_laser = ASourceCreator.Create2DSource(clip_laser, "Laser");
    }

    public override void ConfigueConsumition(EnergyManager energy)
    {
        base.ConfigueConsumition(energy);
        em.StopCosume += OnRelease;
    }

    public override void OnPress()
    {
        laser.gameObject.transform.localScale = new Vector3(sizeXlaser, sizeYlaser, 1);

        if (em.AddConsume(cant_consume))
        {
            laser.gameObject.SetActive(true);
            
            as_laser.Play();
        }
        else
        {
            laser.gameObject.SetActive(false);
            as_laser.Stop();
        }

    }

    public override void OnRelease()
    {
        laser.gameObject.SetActive(false);
        em.RemoveConsume();
        as_laser.Stop();
    }
}
