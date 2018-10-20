using UnityEngine;

public class ScreenLimits
{
    Transform trans;

    Vector3 zero;
    Vector3 limit;

    public ScreenLimits(Transform _trans)
    {
        trans = _trans;

        zero = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        limit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }

    public void Manual_Update()
    {
        if (trans.position.x > limit.x) trans.position = new Vector3(zero.x, trans.position.y, 0);
        if (trans.position.x < zero.x) trans.position = new Vector3(limit.x, trans.position.y, 0);
        if (trans.position.y > limit.y) trans.position = new Vector3(trans.position.x, zero.y, 0);
        if (trans.position.y < zero.y) trans.position = new Vector3(trans.position.x, limit.y, 0);
    }
}
