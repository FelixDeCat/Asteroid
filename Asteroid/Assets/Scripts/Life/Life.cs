using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : ISubject
{
    List<IObserver> observers = new List<IObserver>();

    int health;

    public int Health
    {
        get { return health; }
        set {
            if (value > -1) {
                if (value > maxHealth) health = maxHealth;
                else {
                    health = value;
                    NotifyObservers();
                }
            }
            else health = 0;
        }
    }

    public void IncreaseLife(int val)
    {
        maxHealth += val;
        Health = maxHealth;
    }

    int maxHealth;

    public Life(int maxlife, params IObserver[] _observers)
    {
        maxHealth = maxlife;
        health = maxlife;
        foreach (var ob in _observers) this.observers.Add(ob);
        InitializeObservers();
    }

    public void NotifyObservers() { foreach (var ob in observers) ob.Notify(health); }
    public void InitializeObservers() { foreach (var ob in observers) ob.Initialize(health); }
    public void Suscribe(IObserver obs) { this.observers.Add(obs); }
    public void UnSuscribe(IObserver obs) { this.observers.Remove(obs); }
}
