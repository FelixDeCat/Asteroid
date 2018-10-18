using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSaveLoad<T> {

    static string path = @"";
    string _nombreDocumento;
    public string textoConvertido;
    public ListObjs listaConvert;
    public List<T> currentObjects;
    public class ListObjs { public T[] array_objects; }

    public JsonSaveLoad(string documentName) {
        _nombreDocumento = documentName;
        currentObjects = new List<T>();
        listaConvert = new ListObjs { array_objects = new T[100] };
        path = @"" + _nombreDocumento + ".txt";
    }

    public void Guardar(List<T> _list) {
        currentObjects = _list;
        listaConvert.array_objects = _list.ToArray();
        Save();
    }

    public List<T> Cargar() {
        Load();
        return currentObjects;
    }

    ///////////////////////////////
    /// SAVE
    ///////////////////////////////
    public void Save()
    {
        ConvertirAString();
        GuardarTexto();
    }
    void ConvertirAString() { textoConvertido = JsonUtility.ToJson(listaConvert); }
    void GuardarTexto() { File.WriteAllText(path, textoConvertido); }

    ///////////////////////////////
    /// SAVE
    ///////////////////////////////

    public void Load()
    {
        CargarTexto();
        ConvertirATipoDeObjeto();
    }
    void CargarTexto()
    {
        Comprobacion();
        textoConvertido = File.ReadAllText(path);
    }
    void ConvertirATipoDeObjeto()
    {
        listaConvert = JsonUtility.FromJson<ListObjs>(textoConvertido);
        foreach (T o in listaConvert.array_objects) { currentObjects.Add(o); }
    }
    void Comprobacion()
    {
        if (File.Exists(path))
        {
            textoConvertido = File.ReadAllText(path);
            if (textoConvertido == "")
            {
                textoConvertido = "{\"currentObjects\":[]}";
                File.WriteAllText(path, textoConvertido);
            }
        }
        else
        {
            File.Create(path);
            File.OpenWrite(path);
            textoConvertido = "{\"currentObjects\":[]}";
            File.WriteAllText(path, textoConvertido);
        }
    }
}
