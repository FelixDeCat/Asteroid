using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PoolSystem;

// 3 cosas solo hay que hacer...

//Heredar de PoolHandler pasandole un tipo de dato que implemente IPooleable
public class BulletHandlerExample : PoolHandler<BulletExample>
{

    float speed;
    Vector3 point;
    int damage;

    GameObject model;
    Transform parent;

    //Implementar el constructor del PoolHandler con el :base + los parametros que se te canten
    public BulletHandlerExample(Vector3 point,GameObject model, Transform parent, float speed, int damage, int cant = 10) : base(cant)
    {
        this.speed = speed;
        this.point = point;
        this.damage = damage;
        this.model = model;
        this.parent = parent;
    }

    //overraidear el Build (Muy Importante), este internamente apunta al delegate del Factory
    protected override BulletExample Build()
    {
        GameObject go = GameObject.Instantiate(model);
        go.transform.SetParent(parent);
        go.transform.position = parent.position;

        BulletExample bullet = go.GetComponent<BulletExample>();
        bullet.speed = speed;
        bullet.damage = damage;
        bullet.point = point;

        return bullet;
    }
}
