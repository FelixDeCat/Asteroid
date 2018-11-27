using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour {

    public int level = 0;

    public static GlobalData instance;

    public void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        Localization.Instance.LoadFromJson("Assets/Languages/en_US.json");
    }

    private void Start()
    {
        Scenes.Load_languageSelector();
    }
}
