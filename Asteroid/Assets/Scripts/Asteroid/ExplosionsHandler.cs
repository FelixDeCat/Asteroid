using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using Tools.Extensions;

public class ExplosionsHandler : PoolHandler<Explosion>, IObserver
{
    GameObject model;
    Transform parent;

    public ExplosionsHandler(GameObject model, Transform parent, int cant = 10) : base(cant)
    {
        this.model = model;
        this.parent = parent;
    }

    protected override Explosion Build()
    {
        var explosion = parent.gameObject.CreateDefaultSubObject<Explosion>("Explosion", model);
        explosion.callback_to_return = OnAnimationEnd;
        return explosion;
    }

    void OnAnimationEnd(Explosion exp)
    {

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
