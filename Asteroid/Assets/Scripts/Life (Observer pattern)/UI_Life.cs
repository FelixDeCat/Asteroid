using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Life : MonoBehaviour, IObserver
{
    Transform parent;

    public Sprite backContainerSprite;
    public Sprite frontContainerSprite;

    [Range(1, 100)]
    public int size = 50;

    List<GraphicContainer> containers = new List<GraphicContainer>();

    void Awake()
    {
        parent = this.transform;
    }

    public void Notify(object obj = null)
    {
        try
        {
            var cant = (int)obj;
            while (containers.Count < cant) containers.Add(CreateContainer(parent));
            for (int i = 0; i < containers.Count; i++)
            {
                int physical_position = i + 1;
                if (physical_position <= cant) containers[i].TurnOn();
                else containers[i].TurnOff();
            }
        }
        catch (System.InvalidCastException ex) { Debug.Log("Can not cast to Int32: " + ex); }
    }

    GraphicContainer CreateContainer(Transform parent)
    {
        var rparent = parent.gameObject.CreateDefaultSubobject<RectTransform>("Container");
        rparent.sizeDelta = new Vector2(size, size);

        var back = rparent.gameObject.CreateDefaultSubobject<Image>("back");
        var front = rparent.gameObject.CreateDefaultSubobject<Image>("front");

        back.rectTransform.Stretch();
        front.rectTransform.Stretch();

        back.sprite = backContainerSprite;
        front.sprite = frontContainerSprite;

        return new GraphicContainer(rparent, back, front);
    }
}
