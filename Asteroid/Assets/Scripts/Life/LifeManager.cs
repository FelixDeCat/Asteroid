using UnityEngine;
using Event = Life.EV_LIFE;

public class LifeManager : MonoBehaviour
{
    Life life;

    public void Config(int life_count, UI_Life ui_life, AudioClip clip_lose_life, AudioClip clip_gain_life)
    {
        life = new Life(life_count)
            .AddEventListener(Event.ON_START, ui_life.OnLifeChange)
            .AddEventListener(Event.GAIN_LIFE, ui_life.OnLifeChange)
            .AddEventListener(Event.LOSE_LIFE, ui_life.OnLifeChange)
            .AddEventListener(Event.LOSE_LIFE, new SoundHandler(clip_lose_life).OnNotify)
            .AddEventListener(Event.GAIN_LIFE, new SoundHandler(clip_gain_life).OnNotify)
            .Close();
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

    public void SetLife(int newMax)
    {
        life.SetLife(newMax);
    }
}
