public class LifeManager {

    Life life;

    public LifeManager(int _initial_life, params IObserver[] observers)
    {
        life = new Life(_initial_life, observers);
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
