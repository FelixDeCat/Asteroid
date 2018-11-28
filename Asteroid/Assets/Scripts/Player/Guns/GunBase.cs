using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    protected EnergyManager em;

    public virtual void ConfigueConsumition(EnergyManager energy)
    {
        em = energy;
    }

    public abstract void OnPress();
    public abstract void OnRelease();
}
