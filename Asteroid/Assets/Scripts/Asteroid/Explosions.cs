using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

public class Explosion : MonoBehaviour, IPooleable<Explosion> {

    public System.Action<Explosion> callback_to_return;

    public void Activate()
    {
        throw new System.NotImplementedException();
    }

    public void Deactivate()
    {
        throw new System.NotImplementedException();
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
