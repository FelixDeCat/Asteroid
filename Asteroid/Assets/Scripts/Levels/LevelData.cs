using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {

    public string LevelName = "default";
    public string description = "short description";
    public float time_to_initiate_level = 1f;//
    public bool fix_ninja_bug = true;//
    public float energy_recuperation_speed = 0.3f;//
    public int score_per_asteroid = 100;

    public Data_Player data_player;
    public Data_Asteroid data_asteroid;
    public Data_Bullet data_bullet;
    public Data_Bomb data_bomb;
    public Data_laser data_laser;
    public Data_Shield data_shield;

}
[System.Serializable]
public class Data_Player
{
    public int shiplife = 3;//
    public int MaxVelocityMagnitudForShip = 20;//
    public int speedforce = 8;//
    public int speedrunForce;//
    public int rotSpeed = 5;//
}
[System.Serializable]
public class Data_Asteroid
{
    public int AsteroidsInitialSize = 3;//
    public int AsteroidsQuantity = 4;//
    public int AsteroidsSpeed = 5;//
}
[System.Serializable]
public class Data_Bullet
{
    public float time_space_between_bullets = 0.2f;//
    public float bullet_cosume = 1f;//
    public float bullet_speed = 8;//
    public int pool_size = 10;//
    public float bullet_size = 0.5f;//
}
[System.Serializable]
public class Data_Bomb
{
    public int bombs_cosume = 80;//
    public float bomb_force = 2;//
    public float time_to_explode = 3f;//
    public float bomb_size = 0.4f;//
}
[System.Serializable]
public class Data_laser
{
    public float laser_cosume = 1.5f;//
    public float size_X_laser = 0.3f;//
    public float size_Y_laser = 1f;//
}
[System.Serializable]
public class Data_Shield
{
    public float laser_cosume = 0.7f;//
    public float size_X_laser = 1f;//
    public float size_Y_laser = 1f;//
}
