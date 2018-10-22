using UnityEngine;

public class ScreenLimits
{
    Transform trans;

    Vector3 zero;
    Vector3 limit;

    float left;
    float right;
    float up;
    float down;

    public ScreenLimits(Transform _trans, float offset)
    {
        trans = _trans;

        zero = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        limit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        right =     limit.x + offset;
        left =      zero.x - offset;
        up =        limit.y + offset;
        down =      zero.y - offset;
    }

    public void Manual_Update()
    {
        if (trans.position.x > right) trans.position =  new Vector2(left, trans.position.y);
        if (trans.position.x < left) trans.position =   new Vector2(right, trans.position.y);
        if (trans.position.y > up) trans.position =     new Vector2(trans.position.x, down);
        if (trans.position.y < down) trans.position =   new Vector2(trans.position.x, up);
    }
}
