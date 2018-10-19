using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    public static void Stretch(this RectTransform tr)
    {
        tr.anchorMin = new Vector2(0, 0);
        tr.anchorMax = new Vector2(1, 1);
        tr.offsetMax = new Vector2(0, 0);
        tr.offsetMin = new Vector2(0, 0);
    }

    public static void Check<T>(this T val)
    {
        if (val == null) throw new System.NullReferenceException("Youuuuu!! Shall Not!!! Pass!!");
    }

    public static T CreateDefaultSubobject<T>(this GameObject owner, string name) where T: Component
    {
        GameObject go = new GameObject();
        go.name = name;
        T back = go.AddComponent<T>();
        go.transform.SetParent(owner.transform);
        go.transform.localScale = new Vector3(1, 1, 1);
        return back;
    }
}
