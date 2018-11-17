using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    int current_score;

    public Level currentLevel;

    LevelDataLoader loader;
    public Player playerRef;
    public AsteroidsAndEnemies AsteroidsAndEnemies;
    public LifeManager lifemanager;

    public Score scoremanager;

    public SectorManager sectors;

    [Header("For Life")]
    public UI_Life uilife;
    public AudioClip loselife;
    public AudioClip winLife;

    private void Awake()
    {
        currentLevel = new Level();
        loader = new LevelDataLoader();
        loader.AddLevel(new LevelData());
    }

    private void Start()
    {
        var leveldata = loader.GetLevel(0);

        lifemanager.Config(leveldata.shiplife, uilife, loselife, winLife);

        playerRef.Initialize();
        playerRef.Listener_CrashAction(lifemanager.Hit);
        playerRef.maxVelocityMagnitude = leveldata.MaxVelocityMagnitudForShip;
        playerRef.speedForce = leveldata.speedforce;
        playerRef.rotSpeed = leveldata.rotSpeed;

        scoremanager.Initialize(SetScore);

        AsteroidsAndEnemies
            .Initialize()
            .Listener_GetPosToSpawn(sectors.FindRandomPos)
            .Listener_AddScore(scoremanager.ReceiveScore)
            .Set_Asteroids_Quantity(leveldata.AsteroidsQuantity)
            .Set_Asteroids_Force(leveldata.AsteroidsSpeed)
            .Set_Asteroids_InitialSize(leveldata.AsteroidsInitialSize)
            .Set_Asteroids_Life(1);

        currentLevel.StartGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            AsteroidsAndEnemies.SpawnAsteroids();

        currentLevel.UpdateLevel();
    }

    void SetScore(int score) { current_score = score; }
}
