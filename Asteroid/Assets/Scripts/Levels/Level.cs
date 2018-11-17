using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Level
{
    bool play = false;

    public Level()
    {
    }

    public void Pause() { play = false; }
    public void Resume() { play = true; }

    public void StartGame()
    {
        play = true;
    }

    public void UpdateLevel()
    {
        if (!play) return;
    }

    public void EndLevel()
    {
        play = false;
    }
}
