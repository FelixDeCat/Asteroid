using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBase : MonoBehaviour
{
    public abstract void OnPress();
    public abstract void OnRelease();
}
