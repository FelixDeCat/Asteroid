using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : GunBase {

    public GameObject laser;

    private void Awake()
    {
        laser.gameObject.SetActive(false);
    }

    public override void OnPress()
    {
        laser.gameObject.SetActive(true);
    }

    public override void OnRelease()
    {
        laser.gameObject.SetActive(false);
    }
}
