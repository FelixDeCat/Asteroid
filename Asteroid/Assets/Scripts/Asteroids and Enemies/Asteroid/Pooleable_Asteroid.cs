using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PoolSystem;
using Tools.Extensions;
using Random = UnityEngine.Random;


public class Pooleable_Asteroid : MonoBehaviour, IPooleable<Pooleable_Asteroid>
{
    public Action<Pooleable_Asteroid> callback_to_return;
    Rigidbody2D myrb;
    ScreenLimiter screenlimiter;
    public MeshRenderer my_mesh_render;
    public Transform rotator;
    Vector3 rotdir;
    bool move;
    Sensor sensor;
    Vector2 position;
    Vector2 dirvector;

    int _life;
    int Life
    {
        get { return _life; }
        set
        {
            if (_life >= 4) throw new System.Exception("Non valid value, " +
                "life can not be superior to 3");
            else
            {
                _life = value;
                if (value < 1) { Destroy(); }
            }
        }
    }
    int _size;
    public int Size
    {
        get { return _size; }
        set
        {
            if (value > 0 && value < 6)
            {
                _size = value;
                transform.localScale = new Vector3(2 * value, 2 * value, 2 * value);
            }
            else throw new System.Exception("Non valid value, " +
                "size can not be superior to 5 or inferior to 1");
        }
    }

    public void Awake()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
        screenlimiter = new ScreenLimiter(transform);
        sensor = gameObject.FindAndLink<Sensor>();
        sensor.SubscribeAction(OnCollision);
    }

    void OnCollision(GameObject obj)
    {
        var bullet = obj.gameObject.GetComponent<Pooleable_Bullet>();
        if (bullet) bullet.ManualDestroy();

        var player = obj.gameObject.GetComponent<Player>();
        if (player) player.Crash();

        Destroy();
    }

    public void SetDataForSpawn(int param_size, int param_life, Vector3 pos, Vector3 dir, int force = 5)
    {
        Size = param_size;
        Life = param_life;

        transform.position = pos;
        myrb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    public void Activate()
    {
        rotdir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
        my_mesh_render.enabled = true;
        move = true;
        gameObject.name = "Asteroid (Active)";
        sensor.Activate();
        myrb.simulated = true;
    }

    public void Deactivate()
    {
        my_mesh_render.enabled = false;
        move = false;
        gameObject.name = "Asteroid";
        myrb.simulated = false;
        myrb.velocity = Vector2.zero;
        sensor.Deactivate();
    }

    void Update()
    {
        if (!move) return;
        rotator.Rotate(rotdir);
        screenlimiter.Manual_Update();

    }

    public void Destroy()
    {
        callback_to_return(this);
    }
}
