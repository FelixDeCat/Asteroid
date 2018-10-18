using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : ISubject
{
    List<IObserver> observers = new List<IObserver>();

    int health;
    public int Health
    {
        set
        {
            health = value;
            NotifyObservers();
        }
    }

    public Life(int maxlife, params IObserver[] _observers)
    {
        health = maxlife;
        foreach (var ob in _observers) this.observers.Add(ob);
    }

    public void NotifyObservers() { foreach (var ob in observers) ob.Notify(health); }
    public void Suscribe(IObserver obs) { this.observers.Add(obs); }
    public void UnSuscribe(IObserver obs) { this.observers.Remove(obs); }
}
