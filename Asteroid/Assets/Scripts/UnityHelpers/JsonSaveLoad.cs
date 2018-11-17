using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaveLoad<T> {

    static string path = @"";
    string docname;
    public string convertedtext;
    public ListObjs2 objList;
    public List<T> current;
    public class ListObjs { public T[] array_objects; }
    public class ListObjs2 { public List<T> array_objects; }

    public JsonSaveLoad(string _docname) {
        docname = _docname;
        current = new List<T>();
        //objList = new ListObjs { array_objects = new T[100] };
        objList = new ListObjs2 { array_objects = new List<T>() };
        path = @"" + docname + ".txt";
    }

    public void Save(List<T> _list) {
        current = _list;
        //objList.array_objects = _list.ToArray();
        objList.array_objects = _list;
        convertedtext = JsonUtility.ToJson(objList,true);
        File.WriteAllText(path, convertedtext);
    }

    public List<T> Load() {
        Check();
        convertedtext = File.ReadAllText(path);
        objList = JsonUtility.FromJson<ListObjs2>(convertedtext);
        foreach (T o in objList.array_objects) { current.Add(o); }
        return current;
    }

    void Check()
    {
        if (File.Exists(path))
        {
            convertedtext = File.ReadAllText(path);
            if (convertedtext == "")
            {
                convertedtext = "{}";
                File.WriteAllText(path, convertedtext);
            }
        }
        else
        {
            File.Create(path);
            File.OpenWrite(path);
            convertedtext = "{}";
            File.WriteAllText(path, convertedtext);
        }
    }
}
