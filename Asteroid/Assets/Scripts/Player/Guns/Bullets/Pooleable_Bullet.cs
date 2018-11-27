using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using System;
using Tools.Screen;


public class Pooleable_Bullet : MonoBehaviour, IPooleable<Pooleable_Bullet>
{
    public float speed;
    public int damage;
    public SpriteRenderer my_sp_render;
    bool move;
    Rigidbody2D myRb;

    ScreenLimiter slimit;

    void Awake()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        slimit = new ScreenLimiter(this.transform);
    }

    public Action<Pooleable_Bullet> callback_to_return;

    public void Move(Vector3 position, Quaternion dir)
    {

        move = true;
        transform.position = position;
        transform.rotation = dir;
    }

    public void Activate()
    {
        //esta linea
        myRb.simulated = true;
        my_sp_render.enabled = true;
        timer = 0;
        gameObject.name = "Bullet (Active)";
    }
    public void Deactivate()
    {
        myRb.simulated = false;
        my_sp_render.enabled = false;
        timer = 0;
        move = false;
        gameObject.name = "Bullet";
    }

    public void ManualDestroy()
    {
        timer = 0;
        callback_to_return(this);
    }

    float timer;
    void Update()
    {
        slimit.Manual_Update();

        if (move)
        {
            if (timer < 1)
            {
                timer = timer + 1 * Time.deltaTime;
                transform.position += transform.up * speed * Time.deltaTime;
            }
            else
            {
                timer = 0;
                callback_to_return(this);
            }
        }
    }
}
