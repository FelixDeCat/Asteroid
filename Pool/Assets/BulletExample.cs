using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

public class BulletExample : MonoBehaviour, IPooleable<BulletExample>
{
    public float speed;
    public int damage;
    public Vector3 point;
    public SpriteRenderer mysp;

    bool move;


    public void Activate()
    {
        mysp.enabled = true;
        move = true;
        gameObject.name = "Bullet (Active)";
    }

    public void Deactivate()
    {
        mysp.enabled = false;
        move = false;
        gameObject.name = "Bullet";
    }

    void Update()
    {
        if (move)
            transform.forward += transform.forward * 10;
    }

}
