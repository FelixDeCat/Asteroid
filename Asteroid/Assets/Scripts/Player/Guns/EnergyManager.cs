using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnergyManager : MonoBehaviour {

    public event Action StopCosume;

    public float recuperationspeed = 0.3f;

    private float energy;
    public float maxEnergy;
    public float Energy
    {
        get { return energy; }
        set
        {
            energy = value;
            if (value > maxEnergy) energy = maxEnergy;
            else if (value < 0) energy = 0;
        }
    }

    public float totalConsume;

    float timer;

    public Transform pivot;

    public void Configurate(int maxEnergy)
    {
        this.maxEnergy = maxEnergy;
    }


    private void Awake()
    {
        Energy = 100;
    }

    bool rest;
    float timerrest;
    float timetorest = 1f;

    bool consuming;

    public bool AddConsume(float cant) {
        if (Energy > 5)
        {
            totalConsume = cant;
            consuming = true;
            timerrest = 0;
            rest = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void RemoveConsume() { totalConsume = 0; consuming = false; }
    public bool Consume(float cant) {
        if (cant < Energy)
        {
            Energy -= cant;
            timerrest = 0;
            rest = false;
            return true;
        }
        else return false;
    }

    private void Update()
    {
        if (timerrest < timetorest)
        {
            timerrest = timerrest + 1 * Time.deltaTime;
        }
        else
        {
            rest = true;
        }

        if (Energy < 1)
        {
            StopCosume();
        }

        if (timer < 1)
        {
            timer = timer + 1 * Time.deltaTime;
        }
        else
        {
            float aux = Energy;
            if(!consuming)
                if (rest) aux += recuperationspeed;
            aux -= totalConsume;
            Energy = aux;

            float x = Energy;
            pivot.localScale = new Vector3(x, 1, 1);
        }
    }
}
