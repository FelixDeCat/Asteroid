using UnityEngine;
using System;
using PoolSystem;
using Tools.Extensions;
using RandomTool = Tools.Extensions.Extensions;

public class AsteroidsHandler : PoolHandler<Pooleable_Asteroid> {

    GameObject model;
    Transform parent;

    event Action Ev_AllAsteroidsDestroyed;
    event Action<Vector2> Ev_DestroyAsteroid;

    public AsteroidsHandler(GameObject model, Transform parent, Action<Vector2> callback, Action alldestroyed, int poolcant = 24) : base(poolcant)
    {
        this.model = model;
        this.parent = parent;
        Ev_DestroyAsteroid += callback;
        Ev_AllAsteroidsDestroyed += alldestroyed;
    }

    protected override Pooleable_Asteroid Build()
    {
        var asteroid = parent.gameObject.CreateDefaultSubObject<Pooleable_Asteroid>("Asteroid", model);
        asteroid.callback_to_return = OnDestroyAsteroid;
        return asteroid;
    }

    public void OnDestroyAsteroid(Pooleable_Asteroid asteroid)
    {

        Ev_DestroyAsteroid(asteroid.transform.position);

        if (asteroid.Size > 1)
            for (int i = 0; i < 3; i++)
                SpawnAsteroid(asteroid.Size - 1, 1, asteroid.transform.position);

        Release(asteroid);

        if (CheckIfAllObjectIsReleased()) Ev_AllAsteroidsDestroyed();
    }

    public bool CheckIfAllObjectIsReleased()
    {
        return pool.AllObjectsReleased(); }

    public void SpawnAsteroid(int _size, int _life, Vector2 pos)
    {
        var obj = GetObj();
        obj.SetDataForSpawn(_size, _life, pos, RandomTool.RandomVectorDir(),2);
    }
}
