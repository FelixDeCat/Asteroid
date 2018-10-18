using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using System;

public class Pooleable_Bullet : MonoBehaviour, IPooleable<Pooleable_Bullet>
{
    public float speed;
    public int damage;
    public Vector3 point;
    public SpriteRenderer my_sp_render;
    bool move;

    public Action<Pooleable_Bullet> callback_to_return;

    public void Activate()
    {
        //esta linea
        my_sp_render.enabled = true;
        move = true;
        gameObject.name = "Bullet (Active)";
    }
    public void Deactivate()
    {
        my_sp_render.enabled = false;
        move = false;
        gameObject.name = "Bullet";
    }

    float timer;
    void Update()
    {
        if (move)
        {
            if (timer < 3)
            {
                timer = timer + 1 * Time.deltaTime;
            }
            else
            {
                timer = 0;
                callback_to_return(this);
            }
        }
    }
}
