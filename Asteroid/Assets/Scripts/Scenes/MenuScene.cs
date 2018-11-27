using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour {

    

    public void Btn_Play()
    {
        Scenes.Load_LevelSelector();
    }
    public void Btn_Credits()
    {
        Scenes.Load_Credits();
    }
    public void Btn_Options()
    {
        Scenes.Load_Options();
    }
    public void Btn_Exit()
    {
        Application.Quit();
    }
}
