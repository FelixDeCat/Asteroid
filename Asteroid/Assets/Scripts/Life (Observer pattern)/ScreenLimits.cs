using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLimits {

    public delegate void Repos(Vector3 v3);
    Repos Rep;
    Transform trans;

    Vector3 zero;
    Vector3 limit;

    float posX;
    float posY;

    public ScreenLimits(Transform _trans, Repos _rep)
    {
        trans = _trans;
        Rep = _rep;

        zero = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        limit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    public void Manual_Update()
    {
        posX = trans.position.x;
        posY = trans.position.y;

        if (posX > limit.x)
        {
            Rep(new Vector3(zero.x, posY,0));
        }
        if (posX < zero.x)
        {
            Rep(new Vector3(limit.x, posY, 0));
        }
        if (posY > limit.y)
        {
            Rep(new Vector3(posX, zero.y, 0));
        }
        if (posY < zero.y)
        {
            Rep(new Vector3(posX, limit.y, 0));
        }
    }
}
