using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

public class AsteroidsHandler : PoolHandler<Pooleable_Asteroid> {

    GameObject model;
    Transform parent;

    public AsteroidsHandler(GameObject model, Transform parent, int cant = 10) : base(cant)
    {
        this.model = model;
        this.parent = parent;
    }

    protected override Pooleable_Asteroid Build()
    {
        GameObject go = GameObject.Instantiate(model);
        go.transform.SetParent(parent);
        go.transform.localPosition = new Vector3(0, 0, 0);
        Pooleable_Asteroid asteroid = go.gameObject.GetComponent<Pooleable_Asteroid>();
        return asteroid;
    }

    public void SpawnAsteroid(int _size, int _life)
    {
        GetObj().SpawnInfo(_size, _life);
    }
}
