using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;

public class VisualEffectsManager : MonoBehaviour {

    public PostProcessingProfile asd;

    ChromaticAberrationModel chromatic;
    ChromaticAberrationModel.Settings settings;


    private void Awake()
    {
        chromatic = asd.chromaticAberration;
        endanimation = true;
    }

    public void ShootCromaticAberration()
    {
        if (endanimation)
        {
            endanimation = false;
            shootChromaticAberration = true;
        }
    }

    bool shootChromaticAberration;
    float timer;
    public float timing = 1;
    bool back;
    bool endanimation;

    private void Update()
    {
        if (shootChromaticAberration)
        {
            if (timer < timing)
            {
                timer = timer + 3 * Time.deltaTime;
                settings.intensity = Mathf.Lerp(back ?1 :0  , back ? 0 : 1, timer);
                chromatic.settings = settings;
            }
            else
            {
                timer = 0;
                if (!back) { back = true; return; }
                shootChromaticAberration = false;
                back = false;
                endanimation = true;
            }
        }
    }
}
