using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimResurrect : StateMachineBehaviour {

    Action OnResurrectEnd;

    public void AddEventListener_OnResurrectEnd(Action listener) {
        OnResurrectEnd += listener;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnResurrectEnd();
    }
}
