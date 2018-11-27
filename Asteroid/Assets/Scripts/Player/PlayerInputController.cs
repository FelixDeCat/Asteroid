using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Tools.EventClasses;

public class PlayerInputController : MonoBehaviour
{

    public UnityEvent ev_Left_KeyDown;
    public UnityEvent ev_Left_KeyUp;
    public UnityEvent ev_Right_KeyDown;
    public UnityEvent ev_Right_KeyUp;

    public UnityEvent ev_KeyDown_movement;
    public UnityEvent ev_KeyUp_movement;

    public UnityEvent ev_Shoot;
    public UnityEvent ev_cancelhoot;
    public UnityEvent ev_ChangeWeapon;
    public UnityEvent ev_RunActive;
    public UnityEvent ev_RunDeactive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) ev_Right_KeyDown.Invoke();
        if (Input.GetKeyUp(KeyCode.D)) ev_Right_KeyUp.Invoke();
        if (Input.GetKeyDown(KeyCode.A)) ev_Left_KeyDown.Invoke();
        if (Input.GetKeyUp(KeyCode.A)) ev_Left_KeyUp.Invoke();

        if (Input.GetKeyDown(KeyCode.W)) ev_KeyDown_movement.Invoke();
        if (Input.GetKeyUp(KeyCode.W)) ev_KeyUp_movement.Invoke();

        if (Input.GetButtonDown("Fire1")) ev_Shoot.Invoke();
        if (Input.GetButtonUp("Fire1")) ev_cancelhoot.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) ev_ChangeWeapon.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftShift)) ev_RunActive.Invoke();
        if (Input.GetKeyUp(KeyCode.LeftShift)) ev_RunDeactive.Invoke();
    }
}
