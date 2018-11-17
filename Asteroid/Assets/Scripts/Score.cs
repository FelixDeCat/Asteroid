using UnityEngine.UI;
using UnityEngine;
using System;

public class Score : MonoBehaviour {

    [SerializeField] Text txtmain;
    [SerializeField] Text txtaux;
    [SerializeField] Animator anim;
    int score;

    event Action<int> return_score;

    public void Initialize(Action<int> return_score)
    {
        this.return_score += return_score;
    }

    public void ReceiveScore(int add)
    {
        score += add;
        txtmain.text = txtaux.text = score.ToString();
        return_score(score);
        anim.Play("twinkle");
    }
}
