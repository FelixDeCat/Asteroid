using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;
using System;
using Tools.Extensions;

// 3 cosas solo hay que hacer...

//Heredar de PoolHandler pasandole un tipo de dato que implemente IPooleable
public class BulletHandler : PoolHandler<Pooleable_Bullet>
{
    float speed;
    Vector3 point;
    int damage;

    GameObject model;
    Transform parent;

    //Implementar el constructor del PoolHandler con el :base + los parametros que se te canten
    public BulletHandler(Vector3 point,GameObject model, Transform parent, float speed, int damage, int cant = 10) : base(cant)
    {
        this.speed = speed;
        this.point = point;
        this.damage = damage;
        this.model = model;
        this.parent = parent;
    }

    //overraidear el Build (Muy Importante), este internamente apunta al delegate del Factory
    protected override Pooleable_Bullet Build()
    {
        var bullet = parent.gameObject
            .CreateDefaultSubObject<Pooleable_Bullet>("bullet", model);

        bullet.speed = speed;
        bullet.damage = damage;
        bullet.point = point;
        bullet.callback_to_return += Release;

        return bullet;
    }

    public void Shoot()
    {
        var bullet = GetObj();
    }
}
