interface ISubject
{
    void NotifyObservers();
    void Suscribe(IObserver obs);
    void UnSuscribe(IObserver obs);
}