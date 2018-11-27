using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Life
{

    UI_Life uilife;

    //variables
    public enum EV_LIFE { LOSE_LIFE, GAIN_LIFE, ON_START, ON_DEATH }

    public event Action loselife;
    public event Action gainlife;
    public event Action start;
    public event Action death;

    int health;
    int maxHealth;

    public int Health
    {
        get { return health; }
        set
        {
            if (value > -1)
            {
                if (value > maxHealth) health = maxHealth;
                else
                {
                    if (value < health)
                    {
                        gainlife();
                        uilife.OnLifeChange(value);
                    }
                    else if (value > health)
                    {
                        loselife();
                        uilife.OnLifeChange(value);
                    }
                    health = value;
                }
            }
            else
            {
                death();
                health = value;
            }
        }
    }

    //Constructor

    public Life(int maxHealth, UI_Life uilife)
    {
        this.maxHealth = maxHealth;
        health = this.maxHealth;
        this.uilife = uilife;
        uilife.OnLifeChange(health);
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

    public void AddEventListener_LoseLife(Action listener) { loselife += listener; }
    public void AddEventListener_GainLife(Action listener) { gainlife += listener; }
    public void AddEventListener_Death(Action listener) { death += listener; }


    
}
