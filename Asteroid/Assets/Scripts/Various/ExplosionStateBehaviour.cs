using System;
using UnityEngine;
public class ExplosionStateBehaviour : StateMachineBehaviour {
    event Action OnExplosionEnd;
    public void AddListener_OnExplosion(Action listener) { OnExplosionEnd += listener; }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { OnExplosionEnd(); }
}
