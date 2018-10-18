using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsAndEnemies : MonoBehaviour
{
    public AsteroidsHandler asteroidsHandler;

    public GameObject AsteroidModel;
    public Transform AsteroidParent;

    private void Awake()
    {
        asteroidsHandler = new AsteroidsHandler(AsteroidModel, AsteroidParent);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            asteroidsHandler.SpawnAsteroid(3,1);
        }
    }
}
