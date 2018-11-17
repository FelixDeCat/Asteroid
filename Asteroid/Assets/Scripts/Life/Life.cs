using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Life
{

    //variables
    public enum EV_LIFE { LOSE_LIFE, GAIN_LIFE, ON_START }

    public event Action<int> loselife;
    public event Action<int> gainlife;
    public event Action<int> start;

    int health;
    int maxHealth;

    public int Health
    {
        get { return health; }
        set {
            if (value > -1) {
                if (value > maxHealth) health = maxHealth;
                else {
                    if (value < health) loselife(value);
                    else if(value > health) gainlife(value);
                    health = value;
                }
            }
            else health = 0;
        }
    }

    //Constructor

    public Life(int maxlife)
    {
        maxHealth = maxlife;
        health = maxlife;
    }

    //Functions

    public void IncreaseLife(int val)
    {
        maxHealth += val;
        Health = maxHealth;
    }

    public void SetLife(int val)
    {
        maxHealth = val;
        Health = maxHealth;
    }

    public Life AddEventListener(EV_LIFE event_type, Action<int> lifechange)
    {
        if (event_type == EV_LIFE.GAIN_LIFE) gainlife += lifechange;
        if (event_type == EV_LIFE.LOSE_LIFE) loselife += lifechange;
        if (event_type == EV_LIFE.ON_START) start += lifechange;
        return this;
    }

    public Life Close()
    {
        start(health);
        return this;
    }
}
