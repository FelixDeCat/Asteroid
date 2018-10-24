using System.Collections;
using System.Collections.Generic;

namespace Tools.Extensions
{
    using UnityEngine;

    public static class Extensions
    {
        //para strechear un componente UI dentro de otro. si es que no se va a mover en ejecución
        public static void Stretch(this RectTransform tr)
        {
            tr.anchorMin = new Vector2(0, 0);
            tr.anchorMax = new Vector2(1, 1);
            tr.offsetMax = new Vector2(0, 0);
            tr.offsetMin = new Vector2(0, 0);
        }

        public static void Stretch<T>(this T obj) where T : UnityEngine.UI.Graphic
        {
            obj.rectTransform.anchorMin = new Vector2(0, 0);
            obj.rectTransform.anchorMax = new Vector2(1, 1);
            obj.rectTransform.offsetMax = new Vector2(0, 0);
            obj.rectTransform.offsetMin = new Vector2(0, 0);
        }

        public static T CreateDefaultSubObject<T>(this GameObject owner, string name) where T : Component
        {
            GameObject go = new GameObject();
            go.name = name;
            T back = go.AddComponent<T>();
            go.transform.SetParent(owner.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(1, 1, 1);
            return back;
        }

        public static T CreateDefaultSubObject<T>(this GameObject owner, string name, GameObject model) where T : Component
        {
            GameObject go = GameObject.Instantiate(model);
            go.name = name;
            T back = go.GetComponent<T>();
            go.transform.SetParent(owner.transform);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = new Vector3(1, 1, 1);
            return back;
        }
    }
}

