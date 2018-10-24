public interface IObserver
{
    void Initialize(object obj = default(object));
    void Notify(object obj = default(object));
}


