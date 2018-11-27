using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{

    [SerializeField] Text principalMessage;
    [SerializeField] Text secondaryMessage;

    bool gotimer1;
    bool gotimer2;
    float timer1;
    float timer2;
    float time_in_screen_1;
    float time_in_screen_2;

    public void Show_PrincipalMessage(string text)
    {
        principalMessage.enabled = true;
        principalMessage.text = Localization.Instance.TryGetText(text);
    }
    public void Show_SecondaryMessage(string text)
    {
        secondaryMessage.enabled = true;
        secondaryMessage.text = Localization.Instance.TryGetText(text);
    }
    public void Show_PrincipalMessage(string text, float time)
    {
        principalMessage.enabled = true;
        principalMessage.text = Localization.Instance.TryGetText(text);
        time_in_screen_1 = time;
        gotimer1 = true;
    }
    public void Show_SecondaryMessage(string text, float time)
    {
        secondaryMessage.enabled = true;
        secondaryMessage.text = Localization.Instance.TryGetText(text);
        time_in_screen_2 = time;
        gotimer2 = true;
    }
    public void Off_PrincipalMessage() { principalMessage.enabled = false; }
    public void Off_SecondaryMessage() { secondaryMessage.enabled = false; }

    private void Awake()
    {
        Off_PrincipalMessage();
        Off_SecondaryMessage();
    }

    private void Update()
    {
        if (gotimer1)
        {
            if (timer1 < time_in_screen_1) timer1 = timer1 + 1 * Time.deltaTime;
            else
            {
                timer1 = 0;
                gotimer1 = false;
                principalMessage.enabled = false;
            }
        }
        if (gotimer2)
        {
            if (timer2 < time_in_screen_2) timer2 = timer2 + 1 * Time.deltaTime;
            else
            {
                timer2 = 0;
                gotimer2 = false;
                secondaryMessage.enabled = true;
            }
        }
    }
}
