using UnityEngine;
using Tools.Screen;

public class ScreenLimiter
{
    Transform trans;

    float left;
    float right;
    float up;
    float down;

    float offset = 0.5f;

    public ScreenLimiter(Transform _trans)
    {
        trans = _trans;

        right = ScreenLimits.Right_Superior.x + offset;
        left = ScreenLimits.Left_Inferior.x - offset;
        up = ScreenLimits.Right_Superior.y + offset;
        down = ScreenLimits.Left_Inferior.y - offset;
    }

    public void Manual_Update()
    {
        if (trans.position.x > right) trans.position = new Vector2(left, trans.position.y);
        if (trans.position.x < left) trans.position = new Vector2(right, trans.position.y);
        if (trans.position.y > up) trans.position = new Vector2(trans.position.x, down);
        if (trans.position.y < down) trans.position = new Vector2(trans.position.x, up);
    }
}
