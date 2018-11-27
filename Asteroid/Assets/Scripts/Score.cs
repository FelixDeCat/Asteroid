using UnityEngine.UI;
using UnityEngine;
using System;

public class Score : MonoBehaviour {

    [SerializeField] Text txtmain;
    [SerializeField] Text txtaux;
    [SerializeField] Animator anim;
    int val;

    public int GetScore()
    {
        return val;
    }

    private void Awake()
    {
        val = 0;
        txtmain.text = txtaux.text = val.ToString();
    }

    public void ReceiveScore(int add)
    {
        val += add;
        txtmain.text = txtaux.text = val.ToString();
        anim.Play("twinkle");
    }
}
