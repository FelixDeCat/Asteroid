using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    Life life;

    public UI_Life uilife;

    private void Start()
    {
        life = new Life(3,uilife);
    }

    public void Hit()
    {
        life.Health--;
    }

    public void AddHealth()
    {
        life.Health++;
    }

    public void IncreaseLife()
    {
        life.IncreaseLife(1);
    }
}
