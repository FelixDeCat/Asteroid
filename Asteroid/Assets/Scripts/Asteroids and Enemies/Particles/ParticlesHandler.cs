using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using Tools.Extensions;

public class ParticlesHandler : PoolHandler<ParticleObj>, IObserver
{
    GameObject model;
    Transform parent;

    public ParticlesHandler(GameObject model, Transform parent, int cant = 30) : base(cant)
    {
        this.model = model;
        this.parent = parent;
    }

    protected override ParticleObj Build()
    {
        var explosion = parent.gameObject.CreateDefaultSubObject<ParticleObj>("Explosion", model);
        explosion.callback_to_return = OnAnimationEnd;
        return explosion;
    }

    public void Spawn(Vector2 position)
    {
        var obj = GetObj();
        obj.Repos(position);
    }

    void OnAnimationEnd(ParticleObj exp)
    {
        pool.ReleaseObject(exp);
        parent.gameObject.name = " Particles (" +pool.ActiveCount()+ ")";
    }

    public void Initialize(object obj = null)
    {
        //nada
    }

    public void Notify(object obj = null)
    {
        GetObj();
    }
}
