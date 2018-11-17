using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidsAndEnemies : MonoBehaviour
{
    private AsteroidsHandler asteroidsHandler;
    private ParticlesHandler particlesHandler;
    private int asteroids_initialSize = 3;
    private int asteroids_quantity = 4;
    private int asteroids_speed = 5;
    private int asteroids_life = 1;
    private event Func<Vector2> GetPosToSpawn;
    private event Action<int> AddScore;

    [SerializeField] private GameObject AsteroidModel;
    [SerializeField] private Transform AsteroidParent;

    [SerializeField] private GameObject ParticlesModel;
    [SerializeField] private Transform ParticlesParent;

    public AsteroidsAndEnemies Initialize()
    {
        asteroidsHandler = new AsteroidsHandler(AsteroidModel, AsteroidParent, OnAsteroidDestroyed);
        particlesHandler = new ParticlesHandler(ParticlesModel, ParticlesParent);
        return this;
    }
    public AsteroidsAndEnemies Listener_GetPosToSpawn(Func<Vector2> _GetPosToSpawn) { GetPosToSpawn += _GetPosToSpawn; return this; }
    public AsteroidsAndEnemies Listener_AddScore(Action<int> _addScore) { AddScore += _addScore; return this; }
    public AsteroidsAndEnemies Set_Asteroids_InitialSize(int val) { asteroids_initialSize = val; return this; }
    public AsteroidsAndEnemies Set_Asteroids_Quantity(int val) { asteroids_quantity = val; return this; }
    public AsteroidsAndEnemies Set_Asteroids_Force(int val) { asteroids_speed = val; return this; }
    public AsteroidsAndEnemies Set_Asteroids_Life(int val) { asteroids_life = val; return this; }



    void OnAsteroidDestroyed(Vector2 pos)
    {
        AddScore(100);
        particlesHandler.Spawn(pos);
    }

    public void SpawnAsteroids()
    {
        for (int i = 0; i < asteroids_quantity; i++)
            asteroidsHandler.SpawnAsteroid(
                asteroids_initialSize,
                asteroids_life,
                GetPosToSpawn());
    }
}
