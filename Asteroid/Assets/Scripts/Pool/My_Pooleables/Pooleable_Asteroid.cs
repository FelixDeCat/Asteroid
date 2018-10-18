using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PoolSystem;

public class Pooleable_Asteroid : MonoBehaviour, IPooleable<Pooleable_Asteroid> {

    public Action<Pooleable_Asteroid, int> callback_to_return;

    public SpriteRenderer my_sp_render;
    bool move;

    int _life;
    int Life {
        get { return _life; }
        set {
            if (_life >= 4) throw new System.Exception("Non valid value, " +
                "life can not be superior to 3");
            else {
                _life = value;
                if (value < 1) { Destroy(); }
            }
        }
    }

    int _size;
    int Size {
        get { return _size; }
        set {
            if (value > 0 && value < 4) {
                _size = value;
                transform.localScale = new Vector3(2*value,2*value,2*value);
            }
            else throw new System.Exception("Non valid value, " +
                "size can not be superior to 3 or inferior to 1");
        }
    }

    public void SpawnInfo(int param_size, int param_life)
    {
        Size = param_size;
        Life = param_life;
    }

    public void Activate()
    {
        my_sp_render.enabled = true;
        move = true;
        gameObject.name = "Asteroid (Active)";
    }

    public void Deactivate()
    {
        my_sp_render.enabled = false;
        move = false;
        gameObject.name = "Asteroid";
    }

    public void Destroy()
    {
        callback_to_return(this, Size);
    }
}
