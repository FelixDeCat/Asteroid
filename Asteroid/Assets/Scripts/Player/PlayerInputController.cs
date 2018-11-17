using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Tools.EventClasses;

public class PlayerInputController : MonoBehaviour {

    public EventFloat ev_Rotator;
    public UnityEvent ev_movement;
    public UnityEvent ev_Shoot;
    public UnityEvent ev_cancelhoot;
    public UnityEvent ev_ChangeWeapon;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) ev_Rotator.Invoke(-1);
        if (Input.GetKey(KeyCode.A)) ev_Rotator.Invoke(1);
        if (Input.GetKey(KeyCode.W)) ev_movement.Invoke();
        if (Input.GetButtonDown("Fire1")) ev_Shoot.Invoke();
        if (Input.GetButtonUp("Fire1")) ev_cancelhoot.Invoke();
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt)) ev_ChangeWeapon.Invoke();
    }
}
