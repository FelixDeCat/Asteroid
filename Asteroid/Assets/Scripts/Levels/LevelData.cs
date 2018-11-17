﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {

    public string LevelName = "default";
    public string BuildSceneName = "SceneName";

    public int AsteroidsInitialSize = 3;//
    public int AsteroidsQuantity = 4;//
    public int AsteroidsSpeed = 5;//

    public int shiplife = 3;//
    public int MaxVelocityMagnitudForShip = 20;//
    public int speedforce = 8;//
    public int rotSpeed = 5;//

    public int timeToSpawnEnemies = 10;
    public int temporalSpaceBetweenEnemies = 10;
}