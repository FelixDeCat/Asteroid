using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Sound;

public class ManualGun : GunBase
{
    public GameObject bullet_model;
    public Transform bullet_parent;
    public Transform pointToShoot;

    public AudioClip clip_shoot;
    AudioSource as_shoot;

    bool shoot;
    float timer;

    public float bulletSpeed = 8;
    public float BulletSize = 0.5f;
    public int bulletsInPool = 20;
    public float timingbetwenbullets = 0.2f;
    public float bulletCosume = 1;


    BulletHandler bulletHandle;

    private void Start()
    {
        as_shoot = ASourceCreator.Create2DSource(clip_shoot, "bomb");

        bulletHandle = new BulletHandler(bullet_model, bullet_parent, bulletSpeed, BulletSize, bulletsInPool);
        bulletHandle.GetPosition += this.GetPosition;
        bulletHandle.GetDirection += this.GetDirection;
    }

    Vector3 GetPosition() { return pointToShoot.transform.position; }
    Quaternion GetDirection() { return pointToShoot.transform.rotation;  }

    public override void OnPress()
    {
        shoot = true;
    }

    public override void OnRelease()
    {
        shoot = false;
        timer = 0;
    }

    private void Update()
    {
        if (shoot)
        {
            if (timer == 0)
            {
                if (em.Consume(bulletCosume))
                {
                    as_shoot.Play();
                    Shoot();
                }
            }
            timer = timer < timingbetwenbullets ? timer + 1 * Time.deltaTime : 0;
        }
    }

    void Shoot()
    {
        bulletHandle.Shoot();
    }
}
