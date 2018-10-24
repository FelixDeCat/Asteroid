using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using random = UnityEngine.Random;
using Tools.Screen;
using Tools.Extensions;

public class AsteroidsHandler : PoolHandler<Pooleable_Asteroid>, ISubject {

    GameObject model;
    Transform parent;

    List<IObserver> observers = new List<IObserver>();

    public AsteroidsHandler(GameObject model, Transform parent, int cant = 10, params IObserver[] observers) : base(cant)
    {
        this.model = model;
        this.parent = parent;

        foreach (var o in observers)
        {
            o.Initialize();
            Suscribe(o);
        }
    }

    protected override Pooleable_Asteroid Build()
    {
        var asteroid = parent.gameObject.CreateDefaultSubObject<Pooleable_Asteroid>("Asteroid", model);
        asteroid.callback_to_return = OnDestroyAsteroid;

        return asteroid;
    }

    public void OnDestroyAsteroid(Pooleable_Asteroid asteroid, int size)
    {
        NotifyObservers(asteroid.gameObject.transform.position);

        if (size > 1)
        {
            //aca instancio mas asteroids
        }
    }

    public Vector2 RandomVectorDir(Vector3 v3)
    {
        float x = v3.x + random.Range(-1, 1);
        float y = v3.y + random.Range(-1, 1);

        var aux = new Vector2(x,y).normalized;

        return aux;
    }

    public Vector2 RandomPosition()
    {
        float x = random.Range(ScreenLimits.Left_Inferior.x, ScreenLimits.Right_Superior.x);
        float y = random.Range(ScreenLimits.Left_Inferior.y, ScreenLimits.Right_Superior.y);

        return new Vector2(x, y);
    }

    public void SpawnAsteroid(int _size, int _life)
    {
        GetObj().SetDataForSpawn(_size, _life,RandomPosition(), RandomVectorDir(RandomPosition()));
    }

    public void NotifyObservers(Vector3 pos)
    {
        observers.ForEach(x => x.Notify(pos));
    }

    public void Suscribe(IObserver obs)
    {
        observers.Add(obs);
    }

    public void UnSuscribe(IObserver obs)
    {
        observers.Remove(obs);
    }

    public void NotifyObservers()
    {
        //en desuso
    }
}
