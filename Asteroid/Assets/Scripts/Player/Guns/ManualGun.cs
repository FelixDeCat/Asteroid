using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualGun : GunBase
{
    public GameObject bullet_model;
    public Transform bullet_parent;
    public Transform pointToShoot;

    bool shoot;
    float timer;

    BulletHandler bulletHandle;

    private void Start()
    {
        bulletHandle = new BulletHandler(bullet_model, bullet_parent, 8, 10, 10);
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
            if (timer == 0) Shoot();
            timer = timer < 0.2f ? timer + 1 * Time.deltaTime : 0;
        }
    }

    void Shoot()
    {
        bulletHandle.Shoot();
    }
}
