using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Tools.Extensions;

public class UI_Life : MonoBehaviour
{

    public Sprite backContainerSprite;
    public Sprite frontContainerSprite;

    [Range(1, 100)]
    public int size = 50;

    List<GraphicContainer> containers = new List<GraphicContainer>();

    public void OnLifeChange(int value)
    {
        while (containers.Count < value) containers.Add(CreateContainer());
        for (int i = 0; i < containers.Count; i++)
        {
            int physical_position = i + 1;
            if (physical_position <= value) containers[i].TurnOn();
            else containers[i].TurnOff();
        }
    }

    GraphicContainer CreateContainer()
    {
        var rparent = this.transform.gameObject.CreateDefaultSubObject<RectTransform>("Container");
        rparent.sizeDelta = new Vector2(size, size);

        var back = rparent.gameObject.CreateDefaultSubObject<Image>("back");
        var front = rparent.gameObject.CreateDefaultSubObject<Image>("front");

        back.Stretch();
        front.Stretch();

        back.sprite = backContainerSprite;
        front.sprite = frontContainerSprite;

        return new GraphicContainer(back, front);
    }

    
}
