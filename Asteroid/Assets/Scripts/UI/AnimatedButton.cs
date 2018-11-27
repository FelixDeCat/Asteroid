using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnimatedButton : MonoBehaviour {

    FlyWeightAnimatedButton flyref;

    Text text;
    Image btn;
    public bool invertcolor;

    public UnityEvent uevent;

    float timer;
    bool anim;

    Vector3 originalpos;
    Vector3 animpos;

    private void Awake()
    {
        text = gameObject.GetComponentInChildren<Text>();
        btn = gameObject.GetComponent<Image>();
        flyref = FindObjectOfType<FlyWeightAnimatedButton>();
        text.color = Color.white;
        btn.color = new Color(0, 0, 0, 0);
        originalpos = btn.transform.localScale;
        animpos = btn.transform.localScale * 0.9f;

    }

    public void OnPointerEnter()
    {
        btn.color = Color.white;
        text.color = invertcolor ? Color.black : Color.white;
        flyref.PlayMouseOver();
        anim = true;
        timer = 0;
    }
    public void OnPointerExit()
    {
        text.color = Color.grey;
        text.color = invertcolor ? Color.white : Color.black;
        btn.color = new Color(0, 0, 0, 0);
        anim = false;
        timer = 0;
        btn.transform.localScale = originalpos;
    }

    public void OnPointerDown()
    {
        flyref.PlayMouseClick();
        Invoke("Execute", 0.5f);
    }

    void Execute()
    {
        uevent.Invoke();
    }

    private void Update()
    {
        if (anim)
        {
            if (timer < 1f)
            {
                timer = timer + 10 * Time.deltaTime;
                btn.rectTransform.localScale = Vector3.Lerp(animpos, originalpos, timer);
            }
            else
            {
                timer = 0;
                anim = false;
            }
        }
    }
}
