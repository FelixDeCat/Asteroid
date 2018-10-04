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


    public void Activate()
    {
        mysp.enabled = true;
    }

    public void Deactivate()
    {
        mysp.enabled = false;
    }
}
