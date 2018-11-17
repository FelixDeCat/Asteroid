using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extensions;
using System;

public class Player : MonoBehaviour
{
    public int maxVelocityMagnitude;
    public int speedForce;
    public int rotSpeed;

    public event Action CrashAction;

    public Rigidbody2D rb2d;
    ScreenLimiter screenlimits;

    public GunBase[] guns;
    int gunindex = 0;

    public void Crash() { CrashAction(); }
    public void Initialize() { screenlimits = new ScreenLimiter(transform); }
    public void Listener_CrashAction(Action crash) { CrashAction += crash; }

    public void EV_NextWeapon() { gunindex.NextIndex(guns.Length); }
    public void EV_OnPressToShoot() { guns[gunindex].OnPress(); }
    public void EV_OnReleaseToShoot() { guns[gunindex].OnRelease(); }
    public void EV_OnMoveForward() { if (rb2d.velocity.magnitude < maxVelocityMagnitude) rb2d.AddForce(transform.up * speedForce, ForceMode2D.Force); }
    public void EV_OnRotate(float r) { transform.Rotate(0, 0, rotSpeed * r); }

    void Update()
    {
        screenlimits.Manual_Update();
    }
}
