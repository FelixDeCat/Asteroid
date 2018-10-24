using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PoolSystem;


public class Pooleable_Asteroid : MonoBehaviour, IPooleable<Pooleable_Asteroid> {

    public Action<Pooleable_Asteroid, int> callback_to_return;

    Rigidbody2D myrb;
    Collider2D myCollider;

    ScreenLimiter screenlimiter;

    public SpriteRenderer my_sp_render;
    bool move;

    Vector2 position;
    Vector2 dirvector;

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

    public void Awake()
    {
        myrb = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<Collider2D>();
        screenlimiter = new ScreenLimiter(transform);
    }

    public void SetDataForSpawn(int param_size, int param_life, Vector3 pos, Vector3 dir, int force = 5)
    {
        Debug.Log("A");
        Size = param_size;
        Life = param_life;

        transform.position = pos;
        myrb.AddForce(dir * force, ForceMode2D.Impulse);
    }

    public void Activate()
    {
        my_sp_render.enabled = true;
        move = true;
        gameObject.name = "Asteroid (Active)";
        myCollider.enabled = true;
    }

    public void Deactivate()
    {
        my_sp_render.enabled = false;
        move = false;
        gameObject.name = "Asteroid";
        myCollider.enabled = false;
        myrb.velocity = Vector2.zero;
    }

    void Update()
    {
        if (!move) return;
        screenlimiter.Manual_Update();
    }

    public void Destroy()
    {
        callback_to_return(this, Size);
    }
}
