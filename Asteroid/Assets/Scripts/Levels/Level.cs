using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level
{
    #region condicionales y timers
    bool play = false;
    float timer_go_center;
    float time_to_go_center = 1;
    bool animEndLevel = false;
    public float timer;
    bool player_momentarily_destroyed;
    float timer_player_destroyed;
    float time_to_wait_player_destroyed = 1;
    bool lastlife;
    bool init_timer_initiate_level;
    float timer_initiate_level;
    float time_to_initiate_level;

    bool endmessage;
    float timer_end_message;
    float time_to_show_end_message = 2f;

    #endregion
    #region captura de datos
    AudioDBase audioDB;
    Asteroids asteroids;
    Message message;
    Player player;
    Transform spawnpoint;
    VisualEffectsManager visualeffects;
    GameObject menulose;
    GameObject menuwin;
    #endregion

    public Level(LevelData leveldata, Transform spawpoint, Player playerRef,
        LifeManager lifemanager, VisualEffectsManager visualeffects,
        Asteroids asteroids, SectorManager sectors, Score scoremanager,
        AudioDBase audioDataBase, Message messages, GameObject menulose, GameObject menuwin)
    {
        audioDB = audioDataBase;
        this.message = messages;
        time_to_initiate_level = leveldata.time_to_initiate_level;
        this.spawnpoint = spawpoint;
        this.menulose = menulose;
        this.menuwin = menuwin;

        this.visualeffects = visualeffects;

        lifemanager.Config(leveldata.shiplife, OnLoseALife, OnGainALife, OnDeath);

        playerRef.Listener_CrashAction(lifemanager.Hit);
        playerRef.Listener_CrashAction(PlayerDestroyed);
        playerRef.maxVelocityMagnitude = leveldata.MaxVelocityMagnitudForShip;
        playerRef.speedForce = leveldata.speedforce;
        playerRef.speedRunForce = leveldata.speedrunForce;
        playerRef.rotSpeed = leveldata.rotSpeed;
        playerRef.ShootChromaticAberration += visualeffects.ShootCromaticAberration;
        playerRef.spawpoint = spawpoint;


        player = playerRef;
        player.gameObject.transform.position = spawpoint.position;
        player.gameObject.transform.rotation = spawpoint.rotation;

        asteroids
            .Initialize()
            .Listener_GetPosToSpawn(sectors.FindRandomPos)
            .Listener_AddScore(scoremanager.ReceiveScore)
            .Listener_AllDestroyed(EndLevel)
            .Set_Asteroids_Quantity(leveldata.AsteroidsQuantity)
            .Set_Asteroids_Force(leveldata.AsteroidsSpeed)
            .Set_Asteroids_InitialSize(leveldata.AsteroidsInitialSize)
            .Set_Asteroids_Life(1);

        this.asteroids = asteroids;
    }

    public void Initialize()//desde afuera
    {
        player.Initialize();
        init_timer_initiate_level = true;
    }

    public void StartGame()//con timer
    {
        play = true;
        asteroids.SpawnAsteroids();
    }

    public void Pause()
    {
        play = false;
        //menues, desplegar
    }
    public void Resume()
    {
        play = true;
        //menues, desaparecer
    }

    public void UpdateLevel()//desde afuera
    {
        #region Timer to initiate level
        if (init_timer_initiate_level)
        {
            if (timer_initiate_level < time_to_initiate_level) timer_initiate_level = timer_initiate_level + 1 * Time.deltaTime;
            else
            {
                timer_initiate_level = 0;
                init_timer_initiate_level = false;
                StartGame();
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                timer_initiate_level = 0;
                init_timer_initiate_level = false;
                StartGame();
            }
        }
        #endregion
        #region Timer to go center and go light speed
        if (animEndLevel)
        {
            if (timer_go_center < time_to_go_center)
            {
                timer_go_center = timer_go_center + 1f * Time.deltaTime;
                player.transform.position = Vector3.Lerp(player.transform.position, spawnpoint.transform.position, timer_go_center);
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, spawnpoint.transform.rotation, timer_go_center);
            }
            else
            {
                animEndLevel = false;
                timer_go_center = 0;

                Win();
                
            }
        }
        #endregion
        #region Timer to return the ship to the stage
        if (player_momentarily_destroyed)
        {
            if (timer_player_destroyed < time_to_wait_player_destroyed) timer_player_destroyed = timer_player_destroyed + 1 * Time.deltaTime;
            else
            {
                player_momentarily_destroyed = false;
                timer_player_destroyed = 0;
                ReturnTheShip();
            }
        }
        #endregion
        #region Timer to show edn message
        if (endmessage)
        {
            if (timer_end_message < time_to_show_end_message)
            {
                timer_end_message = timer_end_message + 1 * Time.deltaTime;
            }
            else
            {
                ActivateMenuWin();
            }
        }
        #endregion
        if (!play) return;

        player.ManualUpdate();
    }

    public void Win()
    {
        visualeffects.ShootCromaticAberration();
        player.movement.LightSpeed();
        player.trail.enabled = true;
        endmessage = true;
    }

    public void ActivateMenuWin()
    {
        message.Show_PrincipalMessage("win");
        menuwin.SetActive(true);
    }

    public void EndLevel()
    {
        animEndLevel = true;
        play = false;
    }

    public void PlayerDestroyed()
    {
        play = false;

        if (lastlife)
        {
            message.Show_PrincipalMessage("lose");
            menulose.SetActive(true);
        }
        else player_momentarily_destroyed = true;
    }

    public void ReturnTheShip()
    {
        play = true;
        player.Resurrect();
    }

    public void OnGainALife()
    {

    }

    public void OnLoseALife()
    {

    }

    public void OnDeath()
    {
        lastlife = true;
    }
}
