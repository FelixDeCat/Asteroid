using UnityEngine;
using System;
using Event = Life.EV_LIFE;

public class LifeManager : MonoBehaviour
{
    Life life;
    public UI_Life uilife;

    public void Config(int life_count, Action OnLoseLife, Action OnGainLife, Action OnDeath)
    {
        life = new Life(life_count, uilife);
        life.AddEventListener_Death(OnDeath);
        life.AddEventListener_GainLife(OnGainLife);
        life.AddEventListener_LoseLife(OnLoseLife);
    }

    public void Hit() { life.Health--; }
    public void AddHealth() { life.Health++; }
    public void IncreaseLife() { life.IncreaseLife(1); }
    public void SetLife(int newMax) { life.SetLife(newMax); }
}
