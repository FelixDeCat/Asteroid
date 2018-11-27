using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour {

    Text text;
    public int level;

    LevelsScene levelsceneref;

    private void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>();
    }

    public void Config(LevelsScene levelscene,int level, string name)
    {
        this.level = level;
        levelsceneref = levelscene;
        text.text = name;
    }


    public void BTN_Click()
    {
        levelsceneref.SetLevelSelected(level);
    }

}
