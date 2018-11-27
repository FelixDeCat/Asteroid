using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using System;

public class ParticleObj : MonoBehaviour, IPooleable<ParticleObj> {

    public Action<ParticleObj> callback_to_return;

    public ParticleSystem myparticle;

    bool check = false;

    public void Activate()
    {
        gameObject.name = "particle (Active)";
        myparticle.Play();
        check = true;
    }

    public void Deactivate()
    {
        gameObject.name = "particle";
        check = false;
        myparticle.Stop();
    }

    public void Update()
    {
        if (!check) return;
        if (myparticle.isStopped)
        {
            EndAnimation();
        }
    }

    public void Repos(Vector2 position)
    {
        this.transform.position = position;
    }

    public void EndAnimation()
    {
        callback_to_return(this);
    }
}
