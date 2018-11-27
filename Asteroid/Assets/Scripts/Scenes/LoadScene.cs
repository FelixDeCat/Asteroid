using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    private void Awake()
    {
        LoadEnglish();
    }

    public void BTN_Accept()
    {
        Scenes.Load_MainMenu();
    }

    public void LoadSpanish()
    {
        Localization.Instance.LoadFromJson("Assets/Languages/es_AR.json");
    }
    public void LoadEnglish()
    {
        Localization.Instance.LoadFromJson("Assets/Languages/en_US.json");
    }

}
