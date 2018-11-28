using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsScene : MonoBehaviour {

    LevelDataLoader leveldataloader;
    public Transform parentLevels;
    public GameObject btnlvlmodel;
    public Text description;

    private void Awake()
    {
        leveldataloader = new LevelDataLoader();

        RefreshLevels();
    }

    void RefreshLevels()
    {
        var levels = leveldataloader.levels;

        for (int i = 0; i < levels.Count; i++)
        {
            GameObject btnlvl = Instantiate(btnlvlmodel);
            btnlvl.gameObject.transform.SetParent(parentLevels);
            btnlvl.transform.localScale = new Vector3(1, 1, 1);
            btnlvl.transform.localPosition = new Vector3(0, 0, 0);

            ButtonLevel btn = btnlvl.gameObject.GetComponent<ButtonLevel>();
            btn.Config(this,i,levels[i].LevelName);
        }

    }

    internal void SetLevelSelected(int level)
    {
        GlobalData.instance.level = level;
        description.text = Localization.Instance.TryGetText(leveldataloader.GetLevel(level).description);
    }

    public void Btn_Play()
    {
        Scenes.Load_Game();
    }

    public void Btn_Back()
    {
        Scenes.Load_MainMenu();
    }
}
