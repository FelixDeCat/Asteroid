using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tools.Extensions;

public class GameManager : MonoBehaviour
{
    public Text debug;

    public Level currentLevel;

    public Transform spawnpoint;

    LevelDataLoader loader;
    public Player playerRef;
    public Asteroids AsteroidsAndEnemies;
    public LifeManager lifemanager;
    public Score scoremanager;
    public SectorManager sectors;
    public VisualEffectsManager visualeffects;
    public AudioDBase AudioDataBase;
    public Message messages;
    public GameObject MenuLose;
    public GameObject MenuWin;
    

    private void Start()
    {
        loader = new LevelDataLoader();
        //loader.AddLevel(new LevelData());//temporal para rellenar el json
        if (GlobalData.instance == null) Scenes.Load_0_LoadScene();

        currentLevel = new Level(loader.GetLevel(GlobalData.instance.level),
            spawnpoint, playerRef, lifemanager, visualeffects, 
            AsteroidsAndEnemies, sectors, scoremanager, 
            AudioDataBase, messages, MenuLose, MenuWin);
        currentLevel.Initialize();
    }

    public void Btn_backToTheMenu()
    {
        Scenes.Load_MainMenu();
    }

    public void Btn_ReloadThisScene()
    {
        Scenes.ReloadThisScene();
    }

    public void Btn_NextLevel()
    {
        GlobalData.instance.level = GlobalData.instance.level.NextIndex(loader.levels.Count);
        Scenes.ReloadThisScene();
    }

    private void Update()
    {
        currentLevel.UpdateLevel();
    }
}
