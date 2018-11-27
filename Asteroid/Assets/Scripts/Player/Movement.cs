using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement
{
    public Rigidbody2D rig;

    event Action event_aceleration;

    TrailRenderer trail;

    ScreenLimiter screenlimits;

    int speedForce;
    int shootAcelerationForce;
    int maxVelocityMagnitude;
    int rotSpeed;

    bool shooteffect;

    bool traileffect;

    public Animator animator;

    Transform transform;

    bool moveforward;
    bool moverun;
    bool moveleft;
    bool moveright;
    public bool Moveforward
    {
        get { return moveforward; }
        set
        {
            moveforward = value;
            animator.SetBool("walk", value);
        }
    }
    public bool Moverun
    {
        get { return moverun; }
        set
        {
            moverun = value;
            animator.SetBool("run", value);
        }
    }
    public bool Moveleft
    {
        get { return moveleft; }
        set
        {
            moveleft = value;
            animator.SetBool("left", value);
        }
    }
    public bool Moveright
    {
        get { return moveright; }
        set
        {
            moveright = value;
            animator.SetBool("right", value);
        }
    }

    public Movement(Rigidbody2D rig, int speedForce, int shootAcelerationForce, int maxVelocityMagnitude, int rotSpeed)
    {
        transform = rig.transform;
        this.rig = rig;
        this.speedForce = speedForce;
        this.shootAcelerationForce = shootAcelerationForce;
        this.maxVelocityMagnitude = maxVelocityMagnitude;
        this.rotSpeed = rotSpeed;
    }

    public void Initialize()
    {
        screenlimits = new ScreenLimiter(transform);
    }

    public Movement SetTrailRenderer(TrailRenderer trail)
    {
        this.trail = trail;
        return this;
    }

    public Movement AddEventListener_AcellerationEffect(Action listener)
    {
        event_aceleration += listener;
        return this;
    }
    public Movement SetAnimator(Animator anim)
    {
        animator = anim;
        return this;
    }

    public void Begin_MoveLeft() { Moveleft = true; }
    public void Exit_MoveLeft() { Moveleft = false; }
    public void Begin_MoveRight() { Moveright = true; }
    public void Exit_MoveRight() { Moveright = false; }
    public void MoveForward_KeyDown() { Moveforward = true; }
    public void MoveForward_KeyUp() { Moveforward = false; }
    public void RunActivated() { Moverun = true; }
    public void RunDeactivated() { Moverun = false; }

    public void LightSpeed()
    {
        trail.enabled = true;
        traileffect = true;
        rig.AddForce(transform.up * speedForce*5, ForceMode2D.Impulse);
    }

    void DeactivateTrail()
    {
        trail.enabled = false;
    }

    float timertrail;
    public void ManualUpdate()
    {
        screenlimits.Manual_Update();

        if (traileffect)
        {
            if (timertrail < 1) timertrail = timertrail + 1 * Time.deltaTime;
            else { traileffect = false; timertrail = 0; DeactivateTrail(); }
        }

        if (moveleft && moveright)
        {
            if (shooteffect)
            {
                shooteffect = false;
                event_aceleration();
            }
            if (rig.velocity.magnitude < maxVelocityMagnitude)
            {
                rig.AddForce(transform.up * speedForce, ForceMode2D.Impulse);
            }   
        }
        else
        {
            shooteffect = true;
            if (Moveleft || Moveright)
            {
                float auxrot = moveleft ? 1 : -1;
                transform.Rotate(0, 0, rotSpeed * auxrot);
            }
            if (Moveforward && rig.velocity.magnitude < maxVelocityMagnitude)
            {
                var auxforce = Moverun ? shootAcelerationForce : 0;
                rig.AddForce(transform.up * (speedForce + auxforce), ForceMode2D.Force);
            }
        }
    }
}
