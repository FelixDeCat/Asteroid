using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GraphicContainer
{
    Image background;
    Image front;
    Transform parent;

    public GraphicContainer(Transform _parent, Image _background, Image _front)
    {
        parent = _parent;
        background = _background;
        front = _front;
    }

    public void TurnOn() { front.enabled = true; }
    public void TurnOff() { front.enabled = false; }

    public void Destroy() { GameObject.Destroy(parent.gameObject); }
}
