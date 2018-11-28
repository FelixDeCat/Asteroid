using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extensions;
using Tools.Sound;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    public int maxVelocityMagnitude;
    public int speedForce;
    public int speedRunForce;
    public int rotSpeed;

    public Animator animator;

    public ParticleSystem burst;
    public ParticleSystem particles_destroy;

    public TrailRenderer trail;

    public event Action advice_to_crash;

    public Transform spawpoint;
    public Rigidbody2D rb2d;
    CircleCollider2D col;

    public AudioClip clip_explosion;
    public AudioClip clip_lightSpeed;
    public AudioClip clip_resurrect;
    AudioSource as_explosion;
    AudioSource as_lightspeed;
    AudioSource as_Resurrect;

    public GunBase[] guns;
    public Sprite[] spriteGuns;
    public Image gunimage;
    public Text textimage;

    public int gunindex = 0;

    public Movement movement;

    bool canshoot;
    bool shoot;
    public bool fix_ninja_bug = true;

    public event Action ShootChromaticAberration;

    public void LigthSpeed()
    {
        movement.LightSpeed();
        LightSpeedSound();
    }

    void LightSpeedSound()
    {
        as_lightspeed.Play();
    }

    public void Initialize()
    {
        col = gameObject.GetComponent<CircleCollider2D>();

        as_explosion = ASourceCreator.Create2DSource(clip_explosion,"explosion");
        as_lightspeed = ASourceCreator.Create2DSource(clip_lightSpeed, "LightSpeed");
        as_Resurrect = ASourceCreator.Create2DSource(clip_resurrect, "Resurrect");

        animator.GetBehaviour<Burst>().SetParticles(burst);
        animator.GetBehaviour<AnimResurrect>().AddEventListener_OnResurrectEnd(OnResurrectAnimationEnded);
        movement = new Movement(rb2d, speedForce, speedRunForce, maxVelocityMagnitude, rotSpeed)
            .AddEventListener_AcellerationEffect(ShootChromaticAberration)
            .AddEventListener_AcellerationEffect(LightSpeedSound)
            .SetAnimator(animator)
            .SetTrailRenderer(trail);
        trail.enabled = false;

        movement.Initialize();

        canshoot = true;
    }

    //1
    public void Crash()
    {
        as_explosion.Play();
        canshoot = false;
        particles_destroy.Play();
        DeactivateCollision();
        advice_to_crash();
        animator.SetBool("destroyed", true);
    }

    //2
    public void Resurrect()
    {
        transform.position = spawpoint.position;
        transform.rotation = spawpoint.rotation;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        as_Resurrect.Play();

        ShootChromaticAberration();

        animator.SetBool("destroyed", false);
    }

    //3
    void OnResurrectAnimationEnded()
    {
        ActivateCollisions();
        canshoot = true;
    }

    void ActivateCollisions() { col.enabled = true; }
    void DeactivateCollision() { col.enabled = false; rb2d.bodyType = RigidbodyType2D.Static; }


    public void Listener_CrashAction(Action crash) { advice_to_crash += crash; }

    public void EV_NextWeapon()
    {
        if (fix_ninja_bug) guns[gunindex].OnRelease();
        gunindex = gunindex.NextIndex(guns.Length);
        gunimage.sprite = spriteGuns[gunindex];
        textimage.text = Localization.Instance.TryGetText(guns[gunindex].name);
        if (fix_ninja_bug && shoot) guns[gunindex].OnPress();
    }
    public void EV_OnPressToShoot()
    {
        if (!canshoot) return;
        shoot = true;
        guns[gunindex].OnPress();
    }
    public void EV_OnReleaseToShoot()
    {
        if (!canshoot) return;
        shoot = false;
        guns[gunindex].OnRelease();
    }
    public void EV_OnBegin_MoveLeft() { movement.Begin_MoveLeft(); }
    public void EV_OnExit_MoveLeft() { movement.Exit_MoveLeft(); }
    public void Ev_OnBegin_MoveRight() { movement.Begin_MoveRight(); }
    public void Ev_OnExit_MoveRight() { movement.Exit_MoveRight(); }
    public void Ev_MoveForward_KeyDown() { movement.MoveForward_KeyDown(); }
    public void Ev_MoveForward_KeyUp() { movement.MoveForward_KeyUp(); }
    public void Ev_RunActivated() { movement.RunActivated(); }
    public void Ev_RunDeactivated() { movement.RunDeactivated(); }
    public void ManualUpdate() { movement.ManualUpdate(); }
}
